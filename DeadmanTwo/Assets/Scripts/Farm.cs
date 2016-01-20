using UnityEngine;
using System.Collections;

public class Farm : Tile
{
	public Farm (int id, bool passable = true, bool isBaseTile = true) : base (id, passable, isBaseTile)
	{
		canJoinTo.Add (TileDatabase.SOIL_ID);
	}


}

