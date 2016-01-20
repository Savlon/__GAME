using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlantableResource : Item
{
	private int _data;
	private Tile _resultTile;
	private List<Tile> _targetTiles = new List<Tile> ();

	public PlantableResource (int id, string name, string description, float delay, int data, Tile resultTile, params Tile[] targetTiles) : base (id, name, description, delay)
	{
		this._data = data;
		this._resultTile = resultTile;

		if (targetTiles != null)
			this._targetTiles = targetTiles.ToList ();
	}

	public override bool InteractOn (Tile tile, Level level, int x, int y, Player player)
	{
//		if (_targetTiles.Count == 0 && _resultTile != null)
//		{
//			if (!_resultTile.Passable && Utils.IsSamePosition (new Vector2 (player.Position.x, player.Position.y), new Vector2 (x, y)))
//				return false;
//
//			level.SetTile (x, y, _resultTile, 0);
//			return true;
//		}
//		if (_targetTiles != null && _resultTile != null)
//		{
//			if (_targetTiles.Contains (tile))
//			{
//				if (!_resultTile.Passable && Utils.IsSamePosition (new Vector2 (player.Position.x, player.Position.y), new Vector2 (x, y)))
//					return false;
//
//				level.SetTile (x, y, _resultTile, 0); //possibly change data value to be the id of the seed?
//				return true;
//			}
//		}
		return false;
	}

	public int Data
	{
		get {return _data;}
		private set {_data = value;}
	}

	public Tile ResultTile
	{
		get {return _resultTile;}
		private set {_resultTile = value;}
	}

	public List<Tile> TargetTiles
	{
		get {return _targetTiles;}
		private set {_targetTiles = value;}
	}
}
