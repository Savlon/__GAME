using UnityEngine;
using System.Collections;

public class Hole : Tile
{
	public Hole (int id, bool passable = true, bool isBaseTile = true) : base (id, passable, isBaseTile)
	{
		canJoinTo.Add (TileDatabase.SHALLOW_WATER_ID);
	}

	public override void StepOn (Level level, int x, int y, Entity source)
	{
		source.Speed = source.NormalSpeed * 0.1f;
	}
}
