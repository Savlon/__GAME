using UnityEngine;
using System.Collections;

public class Mob : Entity
{

	private Direction _direction;

	protected override void Update ()
	{
		base.Update ();
	}

	public override void Move (float x, float y)
	{
		if (x == 0f || y == 0f)
		{
			if (x < 0f) _direction = Direction.LEFT;
			if (x > 0f) _direction = Direction.RIGHT;
			if (y < 0f) _direction = Direction.DOWN;
			if (y > 0f) _direction = Direction.UP;
		}
		else if (x != 0f && y != 0f)
		{
			if (x < 0f && y > 0f) _direction = Direction.UP_LEFT;
			if (x > 0f && y > 0f) _direction = Direction.UP_RIGHT;
			if (x < 0f && y < 0f) _direction = Direction.DOWN_LEFT;
			if (x > 0f && y < 0f) _direction = Direction.DOWN_RIGHT;
		}
		else
		{
			_direction = Direction.NONE;
		}
		base.Move (x, y);
	}


}
