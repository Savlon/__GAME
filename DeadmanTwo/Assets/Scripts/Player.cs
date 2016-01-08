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
			if (_activeItem != null)
			{
				timer = _activeItem.Delay;
				PlayAnimation ();

				if (_activeItem is Food)
				{
					_activeItem.Use (this);
					return;
				}
				else if (_activeItem is Instrument)
				{
					List<Entity> entities = _level.GetEntitiesInArea ((int)mousePosition.x, (int)mousePosition.y, (int)mousePosition.y, (int)mousePosition.x);
					//TODO: Shoot raycast to see if mouse clicked on entity and not self
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
				else if (_activeItem is Seed)
				{
					_activeItem.InteractOn (tile, _level, (int)mousePosition.x, (int)mousePosition.y, this);
					return;
				}

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
	}
}














