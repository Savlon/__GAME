using UnityEngine;
using System.Linq;
using System.Collections;

public class Water : Tile
{
	private Sprite[] images;
	private Sprite[] blueprints;

	private Sprite baseSprite;
	private Sprite overlaySprite;

	public Water (int id, bool passable = true, bool isBaseTile = true) : base (id, passable, isBaseTile)
	{

	}

	public override void Update (Level level, int x, int y)
	{

		for (int yy = -1; yy < 2; yy++)
		{
			for (int xx = -1; xx < 2; xx++) 
			{
				if (Mathf.Abs (xx) == 1 && Mathf.Abs (yy) == 1) continue;

				if (level.GetTile ((float)x + xx, (float)y + yy) == TileDatabase.HOLE)
				{
					level.SetTile ((float)x + xx, (float)y + yy, TileDatabase.WATER, 0);
				}
			}
		}

//		if (level.GetTile ((float)x - 1, (float)y) == TileDatabase.HOLE)
//		{
//			level.SetTile ((float)x - 1, (float)y, TileDatabase.Clone (TileDatabase.WATER, new Vector3 (x - 1, y, 0)), 0);
//		}
//		if (level.GetTile ((float)x + 1, (float)y) == TileDatabase.HOLE)
//		{
//			level.SetTile ((float)x + 1, (float)y, TileDatabase.Clone (TileDatabase.WATER, new Vector3 (x + 1, y, 0)), 0);
//		}
//		if (level.GetTile ((float)x, (float)y - 1) == TileDatabase.HOLE)
//		{
//			level.SetTile ((float)x, (float)y - 1, TileDatabase.Clone (TileDatabase.WATER, new Vector3 (x, y - 1, 0)), 0);
//		}
//		if (level.GetTile ((float)x, (float)y + 1) == TileDatabase.HOLE)
//		{
//			level.SetTile ((float)x, (float)y + 1, TileDatabase.Clone (TileDatabase.WATER, new Vector3 (x, y + 1, 0)), 0);
//		}
	}

	public override void StepOn (Level level, int x, int y, Entity source)
	{
		source.GetComponent <Animator> ().SetBool ("Swim", true);
		source.Speed = source.NormalSpeed * 0.3f;
	}
}
