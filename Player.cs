using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Player {
	public Texture2D texture;
	public Vector2 position;

	public Player(Game game, string pathToTexture, Vector2 position) {
		this.texture = game.Content.Load<Texture2D>(pathToTexture);
		this.position = position;
	}

	public void Draw(SpriteBatch spriteBatch) {
		spriteBatch.Draw(
			this.texture,
			this.position,
			null,
			Color.White,
			0f,
			Vector2.Zero,
			Vector2.One,
			SpriteEffects.None,
			0f
		);
	}
}