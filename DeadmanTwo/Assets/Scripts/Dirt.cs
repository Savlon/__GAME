using UnityEngine;
using System.Collections;

public class Dirt : Tile
{


	public Dirt (int id, bool passable = true, bool isBaseTile = true) : base (id, passable, isBaseTile)
	{	
//		Image = Resources.Load <Sprite> ("Dirt");
	}

	public override bool Interact (Level level, int x, int y, Player player, Item item)
	{
		if (item is Instrument)
		{
			Instrument instrument = (Instrument)item;

			if (instrument.Type == InstrumentType.HOE)
			{
				Debug.Log ("HOE =<> Dirt Tile --> Farming Tile");
				return true;
			}
		}
		return base.Interact (level, x, y, player, item);
	}

}

