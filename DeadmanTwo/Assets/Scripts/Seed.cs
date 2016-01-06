using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Seed : Item
{
	private Tile _resultTile;
	private List<Tile> _targetTiles = new List<Tile> ();

	public Seed (int id, string name, string description, float delay, Tile resultTile, params Tile[] targetTiles) : base (id, name, description, delay)
	{
		this._resultTile = resultTile;
		this._targetTiles = targetTiles.ToList ();
	}

	public override bool InteractOn (Tile tile, Level level, int x, int y, Player player)
	{
		if (_targetTiles != null && _resultTile != null)
		{
			if (_targetTiles.Contains (tile))
			{
				level.SetTile (x, y, _resultTile, 0); //possibly change data value to be the id of the seed?
				return true;
			}
		}
		return false;
	}
}
