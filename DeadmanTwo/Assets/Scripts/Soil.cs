using UnityEngine;
using System.Collections;

public class Soil : Tile
{
	public Soil (int id, bool passable = true, bool isBaseTile = true) : base (id, passable, isBaseTile)
	{
		canJoinTo.Add (TileDatabase.FARM_ID);
	}
		
	public override bool Interact (Level level, int x, int y, Player player, Item item)
	{
		if (item is PlantableResource)
		{
			PlantableResource plantableResource = (PlantableResource)item;
			if (plantableResource.ID == ItemDatabase.WATER_BUCKET.ID)
			{
				level.SetTileOnLayer (x, y, TileDatabase.FARM, 0, 0);
				return true;
			}
		}
		return base.Interact (level, x, y, player, item);
	}
}

