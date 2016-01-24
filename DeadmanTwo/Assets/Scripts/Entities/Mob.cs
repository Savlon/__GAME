using UnityEngine;
using System.Collections;

public class Mob : Entity
{

	public Direction _direction;

	protected override void Update ()
	{
		base.Update ();
	}

	public override void Move (float x, float y)
	{
		if (x == 0f && y == 0f)
		{
			_direction = Direction.NONE;
		}
		else if (x == 0f || y == 0f)
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

		//TODO: CLEAN THIS UP
		if (Mathf.Abs (x) > 0 || Mathf.Abs (y) > 0)
		{
			GetComponent <Animator> ().SetBool ("Walk", true);
		}
		else
			GetComponent <Animator> ().SetBool ("Walk", false);


		
		if (x > 0f)
		{
			float xNext = Mathf.FloorToInt (Position.x + 0.1f);

			if (!_level.GetTileOnLayer (xNext, Position.y, 1).Passable)
				x = 0;
		}
		else if (x < 0f)
		{
			float xNext = Mathf.FloorToInt (Position.x - 0.1f);

			if (!_level.GetTileOnLayer (xNext, Position.y, 1).Passable)
				x = 0;
		}

		if (y > 0f)
		{
			float yNext = Mathf.FloorToInt (Position.y + 0.1f);

			if (!_level.GetTileOnLayer (Position.x, yNext, 1).Passable)
				y = 0;
		}
		else if (y < 0f)
		{
			float yNext = Mathf.FloorToInt (Position.y - 0.1f);

			if (!_level.GetTileOnLayer (Position.x, yNext, 1).Passable)
				y = 0;
		}

		

		base.Move (x, y);
	}


}
