using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Mob
{
	private Item _activeItem;

	protected override void Start ()
	{
		Speed = 4f;
		Health = 90;
		MaxHealth = 100;
		_activeItem = ItemDatabase.SHOVEL;

		base.Start ();
	}

	protected override void Update ()
	{
		Move (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePosition.z = 0;

		if (Input.GetMouseButtonDown (0))
		{
			Tile tile = _level.GetTile (mousePosition.x, mousePosition.y);
			if (_activeItem != null)
			{
				if (_activeItem is Food)
				{
					_activeItem.Use (this);
					return;
				}
				else if (_activeItem is Seed)
				{
					_activeItem.InteractOn (tile, _level, (int)mousePosition.x, (int)mousePosition.y, this);
					return;
				}
				else if (_activeItem is Instrument)
				{
					List<Entity> entities = _level.GetEntitiesInArea ((int)mousePosition.x, (int)mousePosition.y, (int)mousePosition.y, (int)mousePosition.x);
					//TODO: Shooot raycast to see if mouse clicked on entity and not self
					//TODO: this is to decide whether to interact with tile or entity
					if (entities.Count > 0)
					{
						_activeItem.Interact (this, entities[0]);
						return;
					}
					else
					{
						Debug.Log ("ELSE");
						_activeItem.InteractOn (tile, _level, (int)mousePosition.x, (int)mousePosition.y, this);
						return;
					}
				}
			}

		}

//		if (Input.GetMouseButton (1))
//		{
//			_level.SetTile (mousePosition.x, mousePosition.y, TileDatabase.Clone (TileDatabase.SAND, mousePosition), 0);
//		}
//		else if (Input.GetMouseButton (0))
//		{
//			_level.SetTile (mousePosition.x, mousePosition.y, TileDatabase.Clone (TileDatabase.DIRT, mousePosition), 0);
//		}
		base.Update ();
	}
}

