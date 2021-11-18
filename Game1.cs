using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace breakout
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Player player;

        Ball ball;
        BlockManager blockManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 360;
            _graphics.ApplyChanges();

            float centerWidth = _graphics.PreferredBackBufferWidth / 2;
            
            player = new Player(this, "player", new Vector2(centerWidth - 64, _graphics.PreferredBackBufferHeight - 64));
            ball = new Ball(this, "ball", new Vector2(centerWidth - 8, _graphics.PreferredBackBufferHeight - 128));
            
            blockManager = new BlockManager(this, 3, 6);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            var keys = Keyboard.GetState();

            if (keys.IsKeyDown(Keys.Right) && player.position.X + player.texture.Width < _graphics.PreferredBackBufferWidth)
                player.position.X += 250f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keys.IsKeyDown(Keys.Left) && player.position.X > 0)
                player.position.X -= 250f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            player.Draw(_spriteBatch);
            ball.Draw(_spriteBatch);
            blockManager.Draw(_spriteBatch, new Vector2(100, 10));
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
