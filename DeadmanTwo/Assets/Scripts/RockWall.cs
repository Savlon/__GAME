using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class RockWall : Tile
{

	public RockWall (int id, bool passable = true, bool isBaseTile = true) : base (id, passable, isBaseTile)
	{
		
	}

	public override bool Interact (Level Level, int x, int y, Player player, Item item)
	{
		if (item is Instrument)
		{
			Instrument instrument = (Instrument)item;
			if (instrument.Type == InstrumentType.PICKAXE)
			{
				Debug.Log ("Create object in scene");
				return true;
			}
		}
		return false;
	}

}















