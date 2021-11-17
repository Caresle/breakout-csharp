using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BlockManager {
	public int rows;
	public int colums;
	private Game game;

	public BlockManager(Game game, int rows, int columns) {
		this.game = game;
		this.rows = rows;
		this.colums = columns;
	}

	public void Draw(SpriteBatch spriteBatch, Vector2 startPosition) {
		Vector2 changePosition = startPosition;
		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < colums; j++) {
				Block b = new Block(this.game, "block", changePosition);
				b.Draw(spriteBatch, Color.Aqua);
			}
			changePosition = new Vector2(startPosition.X, startPosition.Y + 32);
		}
	}
}