using UnityEngine;
using System.Collections;

public class Player : Mob
{

	protected override void Update ()
	{
		Move (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePosition.z = 0;

		if (Input.GetMouseButton (1))
		{
			_level.SetTile (mousePosition.x, mousePosition.y, TileDatabase.Clone (TileDatabase.GRASS, mousePosition), 0);
		}
		else if (Input.GetMouseButton (0))
		{
			_level.SetTile (mousePosition.x, mousePosition.y, TileDatabase.Clone (TileDatabase.DIRT, mousePosition), 0);
		}
		base.Update ();
	}
}

