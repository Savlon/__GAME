using UnityEngine;
using System.Collections;

public class Farm : Tile
{
	public Farm (int id, bool passable = true, bool isBaseTile = true) : base (id, passable, isBaseTile)
	{
		canJoinTo.Add (TileDatabase.SOIL_ID);
	}

//	public override void Update (Level level, int x, int y)
//	{
//		for (int yy = -1; yy < 2; yy++)
//		{
//			for (int xx = -1; xx < 2; xx++) 
//			{
//				if (Mathf.Abs (xx) == 1 && Mathf.Abs (yy) == 1) continue;
//
//				if (level.GetTile ((float)x + xx, (float)y + yy) == TileDatabase.HOLE)
//				{
//					level.SetTile ((float)x + xx, (float)y + yy, TileDatabase.FARM, 0);
//				}
//			}
//		}
//	}

	public override void StepOn (Level level, int x, int y, Entity source)
	{
		if (source is Player)
		{
			if (Random.Range (0, 101) == 0)
				level.SetTileOnLayer (x, y, TileDatabase.DIRT, 0, 0);
		}
	}

}

