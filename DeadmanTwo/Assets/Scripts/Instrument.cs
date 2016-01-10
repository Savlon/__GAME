using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Instrument : Item
{
	private InstrumentType _type;
	private int _damage;
	private int _interactiveDistance;
	private Tile _resultTile;
	private List<Tile> _targetTiles;

	public Instrument (int id, string name, string description, float delay, InstrumentType type, int damage, int interactiveDistance, Tile resultTile, params Tile[] targetTiles) : base (id, name, description, delay)
	{
		this._type = type;
		this._damage = damage;
		this._interactiveDistance = interactiveDistance;
		this._resultTile = resultTile;
		this._targetTiles = targetTiles.ToList ();
	}

	public override bool Interact (Player player, Entity entity)
	{
		//add attack code to reduce health of opponent
		if (player != null && entity != null)
		{
			if (Vector3.Distance (player.Position, entity.Position) <= 1.5f)
			{
				entity.Health -= _damage;

				Vector3 dir = entity.Position - player.Position;
				dir.Normalize ();

				entity._knockbackX = Mathf.RoundToInt (dir.x) * 10;
				entity._knockbackY = Mathf.RoundToInt (dir.y) * 10;
				return true;
			}
		}
		return false;
	}

	public override bool InteractOn (Tile tile, Level level, int x, int y, Player player)
	{
		if (_targetTiles != null && _resultTile != null)
		{
			//TODO: FIX LOGIC FOR CHECKING WITHIN A RADIUS OF THE PLAYER
			if (Vector3.Distance (player.Position, new Vector3 (x, y, 0)) <= _interactiveDistance)
			{
				if (_targetTiles.Contains (tile))
				{
					level.SetTile (x, y, TileDatabase.Clone (_resultTile, new Vector3 (x, y, 0)), 0);
					return true;
				}
			}
			else
			{
				Debug.Log ("Out of range");
			}
		}
		return false;
	}

	public InstrumentType Type
	{
		get {return _type;} set {_type = value;}
	}

	public int Damage
	{
		get {return _damage;} set {_damage = value;}
	}

	public int InteractiveDistance
	{
		get {return _interactiveDistance;} set {_interactiveDistance = value;}
	}
}

public enum InstrumentType
{
	AXE,
	PICKAXE,
	SHOVEL,
	HOE,
	SWORD
}
