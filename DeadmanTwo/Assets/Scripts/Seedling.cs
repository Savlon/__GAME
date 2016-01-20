using UnityEngine;
using System.Collections;

public class Seedling : Tile
{
	private Tile _resultTile;

	public Seedling (int id, bool passable, bool isBaseTile, Tile resultTile) : base (id, passable, isBaseTile)
	{
		this._resultTile = resultTile;
	}

	public override void Update (Level level, int x, int y)
	{
		if (Random.Range (0, 101) < 90) return;

		level.SetData (x, y, level.GetData (x, y) - 1);

		if (level.GetData (x, y) <= 0)
		{
			level.SetTile (x, y, _resultTile, 0);

			if (level.GetTileOnLayer (x, y, 0).ID == TileDatabase.FARM_ID)
			{
				level.SetTileOnLayer (x, y, TileDatabase.SOIL, 0, 0);
			}
		}
	}

	public override void StepOn (Level level, int x, int y, Entity source)
	{
		if (source is Mob)
		{
			if (Random.Range (0, 101) == 0)
			{
				level.SetTile (x, y, TileDatabase.AIR, 0);
			}
		}

	}


	public Tile ResultTile
	{
		get {return _resultTile;}
		private set {_resultTile = value;}
	}
}

