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
		Debug.Log (player.name + " is attacking " + entity.name + " with a " + _type.ToString ());
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
	SHOVEL,
	HOE,
	SWORD
}
