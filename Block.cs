using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Block : GameObject {
	public Block(Game game, string pathToTexture, Vector2 position) : base(game, pathToTexture, position)
	{}

	public void Draw(SpriteBatch spriteBatch, Color color) {
		spriteBatch.Draw(
			this.texture,
			this.position,
			null,
			color,
			0f,
			Vector2.Zero,
			Vector2.One,
			SpriteEffects.None,
			0f
		);
	}
}