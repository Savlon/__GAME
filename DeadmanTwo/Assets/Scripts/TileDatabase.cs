using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class TileDatabase
{
	public static Tile[] tiles = new Tile[256];

	public static Tile DIRT = new Dirt (0);
	public static Tile GRASS = new Grass (1);
	public static Tile SAND = new Sand (2);
	public static Tile WATER = new Water (3);
	public static Tile HOLE = new Hole (4);


	public static Tile ROCK = new Tile (99, Vector3.zero, false, false);
	public static Tile AIR = new Tile (255, Vector3.zero, true, false);



	private static Dictionary <int, Sprite[]> tilesetDatabase = new Dictionary<int, Sprite[]> ();



	public static Tile Clone (Tile type, Vector3 position)
	{
		return new Tile (type, position);
	}

	public static void LoadTilesetSprites (int id)
	{
		tilesetDatabase = new Dictionary<int, Sprite[]> ();

		Sprite[] tileset = Resources.LoadAll <Sprite> ("Tilesets/" + id + "/TilesetTemplate");
//		tileset = tileset.OrderBy (s => int.Parse (s.name)).ToArray ();

		if (tileset.Length < 48)
			Debug.LogError ("Tile ID: " + id + " does not have a tileset containing 48 sprites.");

		tilesetDatabase.Add (id, tileset);
	}

	public static Sprite[] GetTilesetSprites (int id)
	{
		Sprite[] tileset = null;

		//if (tilesetDatabase.Count == 0)
			LoadTilesetSprites (id);

		if (tilesetDatabase.Count > 0)
		{
			if (tilesetDatabase.ContainsKey (id))
			{
				tileset = tilesetDatabase[id];
			}
		}

		return tileset;
	}
}














