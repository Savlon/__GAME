using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class TileDatabase
{
	/// <summary>
	/// TILE IDS
	/// </summary>
	public static byte DIRT_ID = 0;
	public static byte GRASS_ID = 1;
	public static byte SAND_ID = 2;
	public static byte SHALLOW_WATER_ID = 3;
	public static byte FARM_ID = 4;
	public static byte HOLE_ID = 5;
	public static byte SOIL_ID = 6;
	public static byte ROCK_WALL_ID = 99;
	public static byte AIR_ID = 255;

	/// <summary>
	/// TILE INSTANCES
	/// </summary>
	public static Tile[] tiles = new Tile[256];
	public static Tile DIRT = new Dirt (DIRT_ID);
	public static Tile GRASS = new Grass (GRASS_ID);
	public static Tile SAND = new Sand (SAND_ID);
	public static Tile SHALLOW_WATER = new ShallowWater (SHALLOW_WATER_ID);
	public static Tile SOIL = new Soil (SOIL_ID);
	public static Tile FARM = new Farm (FARM_ID);
	public static Tile HOLE = new Hole (HOLE_ID);
	public static Tile ROCK_WALL = new RockWall (ROCK_WALL_ID, false, false);
	public static Tile AIR = new Tile (AIR_ID, true, false);



	private static Dictionary <int, Sprite[]> tilesetDatabase = new Dictionary<int, Sprite[]> ();
	

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














