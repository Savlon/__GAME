using UnityEngine;
using System.Collections;

public class Hole : Tile
{
	public Hole (int id, Vector3 position = new Vector3 (), bool passable = true) : base (id, position, passable)
	{

	}

	public override void StepOn (Level level, int x, int y, Entity source)
	{
		source.Speed = source.NormalSpeed * 0.1f;
	}
}
