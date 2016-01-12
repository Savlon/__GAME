using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Mob
{
	private Item _activeItem;

	protected override void Start ()
	{
		Speed = 4f;
		NormalSpeed = Speed;
		Health = 90;
		MaxHealth = 100;
		SetActiveItem (ItemDatabase.GetItemFromID (ItemDatabase.SHOVEL.ID));

		base.Start ();
	}

	private float timer;

	protected override void Update ()
	{
		Move (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePosition.z = 0;

		if (transform.localScale.x > 0 && Camera.main.ScreenToViewportPoint (Input.mousePosition).x < 0.5f)
		{
			Vector3 localScale = transform.localScale;
			localScale.x *= -1;
			transform.localScale = localScale;
		}
		else if (transform.localScale.x < 0 && Camera.main.ScreenToViewportPoint (Input.mousePosition).x > 0.5f)
		{
			Vector3 localScale = transform.localScale;
			localScale.x *= -1;
			transform.localScale = localScale;
		}
		timer -= Time.deltaTime;

		if (timer <= 0)
			timer = 0;

		if (Input.GetMouseButton (0) && timer <= 0)
		{
			Tile tile = _level.GetTile (mousePosition.x, mousePosition.y);
			Vector2 selectedTilePos = Utils.FloorVector2 (mousePosition.x, mousePosition.y);

			if (_activeItem != null)
			{
				timer = _activeItem.Delay;

				if (!_activeItem.InteractOn (tile, _level, (int)mousePosition.x, (int)mousePosition.y, this))
					if (_level.GetTile ((int)mousePosition.x, (int)mousePosition.y).Interact (_level, (int)mousePosition.x, (int)mousePosition.y, this, _activeItem))
						return;

				//TODO: CLEAN THIS JUNK UP
				if (_activeItem is Food)
				{
					PlayAnimation ();

					_activeItem.Use (this);
					return;
				}
//				else if (_activeItem is Instrument)
//				{
//					List<Entity> entities = _level.GetEntitiesInArea ((int)mousePosition.x, (int)mousePosition.y, (int)mousePosition.y, (int)mousePosition.x);
//					//TODO: Shoot raycast to see if mouse clicked on entity and not self
//					//TODO: this is to decide whether to interact with tile or entity
//					if (entities.Count > 0)
//					{
//						PlayAnimation ();
//
//						_activeItem.Interact (this, entities[0]);
//						return;
//					}
//					else
//					{
//						Vector2 myTilePos = Utils.FloorVector2 (Position.x, Position.y);
//
//						if (selectedTilePos == myTilePos && !tile.IsBaseTile) return;
//
//						PlayAnimation ();
//
//						if (_activeItem.InteractOn (tile, _level, (int)mousePosition.x, (int)mousePosition.y, this))
//							return;
//						else
//							_level.GetTile ((int)mousePosition.x, (int)mousePosition.y).Interact (_level, (int)mousePosition.x, (int)mousePosition.y, this, _activeItem);
//
//						return;
//					}
//				}
//				else if (_activeItem is PlantableResource)
//				{
//					PlayAnimation ();
//
//					_activeItem.InteractOn (tile, _level, (int)mousePosition.x, (int)mousePosition.y, this);
//					return;
//				}

			}
		}
		else
		{
			transform.GetChild (1).GetComponent <Animator> ().SetBool ("Use", false);
		}

		SwapActiveItemTester ();

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

	public void PlayAnimation ()
	{
		if (_activeItem != null)
		{
			transform.GetChild (1).GetComponent <Animator> ().SetBool ("Use", true);
		}
	}

	public void SetActiveItem (Item item)
	{
		_activeItem = item;
		transform.GetChild (1).GetComponent <SpriteRenderer> ().sprite = _activeItem == null ? null : _activeItem.Image;
	}

	private void SwapActiveItemTester ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha0))
		{
			SetActiveItem (null);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha1))
		{
			SetActiveItem (ItemDatabase.GetItemFromID (ItemDatabase.items[0].ID));
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2))
		{
			SetActiveItem (ItemDatabase.GetItemFromID (ItemDatabase.items[1].ID));
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3))
		{
			SetActiveItem (ItemDatabase.GetItemFromID (ItemDatabase.items[2].ID));
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4))
		{
			SetActiveItem (ItemDatabase.GetItemFromID (ItemDatabase.items[3].ID));
		}
		else if (Input.GetKeyDown (KeyCode.Alpha5))
		{
			SetActiveItem (ItemDatabase.GetItemFromID (ItemDatabase.items[4].ID));
		}		
		else if (Input.GetKeyDown (KeyCode.Alpha6))
		{
			SetActiveItem (ItemDatabase.GetItemFromID (ItemDatabase.items[5].ID));
		}
		else if (Input.GetKeyDown (KeyCode.Alpha7))
		{
			SetActiveItem (ItemDatabase.GetItemFromID (ItemDatabase.items[6].ID));
		}
		else if (Input.GetKeyDown (KeyCode.Alpha8))
		{
			SetActiveItem (ItemDatabase.GetItemFromID (ItemDatabase.items[7].ID));
		}
		else if (Input.GetKeyDown (KeyCode.Alpha9))
		{
			SetActiveItem (ItemDatabase.GetItemFromID (ItemDatabase.items[8].ID));
		}
	}
}














