using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Instrument : Item
{
	private InstrumentType _type;
	private int _damage;
	private Tile _resultTile;
	private List<Tile> _targetTiles;

	public Instrument (string name, string description, InstrumentType type, int damage, Tile resultTile, params Tile[] targetTiles) : base (name, description)
	{
		this._type = type;
		this._damage = damage;
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
			if (_targetTiles.Contains (tile))
			{
				level.SetTile (x, y, TileDatabase.Clone (_resultTile, new Vector3 (x, y, 0)), 0);
				return true;
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
}

public enum InstrumentType
{
	AXE,
	SHOVEL,
	HOE,
	SWORD
}
