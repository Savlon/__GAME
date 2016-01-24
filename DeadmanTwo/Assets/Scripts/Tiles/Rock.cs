using UnityEngine;
using System.Collections;

public class Rock : Tile
{
	public Rock (int id, bool passable = true, bool isBaseTile = false) : base (id, passable, isBaseTile)
	{
		
	}

	public override bool Interact (Level level, int x, int y, Player player, Item item)
	{
		if (item is Instrument)
		{
			Instrument instrument = (Instrument)item;
			if (instrument.Type == InstrumentType.PICKAXE)
			{
				level.SetTile (x, y, TileDatabase.AIR, 0);
				return true;
			}
		}
		return base.Interact (level, x, y, player, item);
	}
}

