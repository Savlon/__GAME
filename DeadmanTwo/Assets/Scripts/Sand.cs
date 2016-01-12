using UnityEngine;
using System.Linq;
using System.Collections;

public class Sand : Tile
{

	public Sand (int id, bool passable = true, bool isBaseTile = true) : base (id, passable, isBaseTile)
	{

	}

	public override void StepOn (Level level, int x, int y, Entity source)
	{
		base.StepOn (level, x, y, source);

		source.Speed = source.NormalSpeed * 0.75f;
	}

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
