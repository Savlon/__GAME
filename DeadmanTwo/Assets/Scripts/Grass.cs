using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Grass : Tile
{

	public Grass (int id, bool passable = true, bool isBaseTile = true) : base (id, passable, isBaseTile)
	{

	}

	public override void Update (Level level, int x , int y)
	{
		if (Random.Range (0, 100) != 0) return;

		float xd = x + Random.Range (-1, 2);
		float yd = y + Random.Range (-1, 2);

		if (level.GetTile (xd, yd) == TileDatabase.DIRT)
		{
			level.SetTile (xd, yd, this, 0);
		}
	}

//
//	public override void StepOn (Level level, int x, int y, Entity source)
//	{
//		if (source is Player)
//		{
//			Debug.Log ("Player on tile");
//			Player player = (Player)source;
//			level.SetTile (x, y, TileDatabase.Clone (TileDatabase.DIRT, new Vector3 (x, y, 0)), 0);
//		}
//		base.StepOn (level, x, y, source);
//	}

	public override bool Interact (Level level, int x, int y, Player player, Item item)
	{
		if (item is Instrument)
		{
			Instrument instrument = (Instrument)item;
			if (instrument.Type == InstrumentType.SHOVEL)
			{
				level.SetTile (x, y, TileDatabase.DIRT, 0);
				return true;
			}
		}
		return base.Interact (level, x, y, player, item);
	}
}
