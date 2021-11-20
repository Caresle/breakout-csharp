using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class BlockManager {
	public int rows;
	public int colums;
	public List<Block> blocks;
	private Game game;

	public BlockManager(Game game, int rows, int columns) {
		this.game = game;
		this.rows = rows;
		this.colums = columns;
		this.blocks = new List<Block>();
	}

	public void FillBlocks(Vector2 startPosition) {
		Vector2 changePosition = startPosition;
		for (int i = 0; i < this.rows; i++) {
			for (int j = 0; j < this.colums; j++) {
				Block b = new Block(this.game, "block", changePosition, Color.BlueViolet);
				this.blocks.Add(b);
				// Change the column position
				changePosition = new Vector2(changePosition.X + 80, changePosition.Y);
			}
			// Change the row position
			changePosition = new Vector2(startPosition.X, startPosition.Y + 32 * (i + 1));
		}
	}

	public void Draw(SpriteBatch spriteBatch) {
		foreach(Block block in this.blocks) {
			if (block.isAlive)
				block.Draw(spriteBatch);
		}
	}

	public void CheckCollision(Ball ball) {
		foreach(Block block in this.blocks) {
			if (block.isAlive)
				if (Utils.isColliding(ball.getRect(), block.getRect()))
					block.isAlive = false;
		}
	}

	public bool CheckIfWin() {
		foreach(Block block in this.blocks) {
			if (block.isAlive)
				return false;
		}
		return true;
	}

	public void ClearBlock(Vector2 startPosition) {
		foreach(Block block in this.blocks) {
			block.isAlive = true;
		}
	}
}