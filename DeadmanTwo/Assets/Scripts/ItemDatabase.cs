using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ItemDatabase
{
	public static Item[] items = new Item[256];

	// FOOD
	public static Item APPLE = new Food (0, "Apple", "Mmmm tasty...", 2.0f, 5);
	public static Item PEAR = new Food (1, "Pear", "Mmmm tasty...", 2.0f, 4);

	// PLANTABLE
	public static Item TREE_SEED = new PlantableResource (2, "Tree Seed", "Grows into tree.", 2.0f, TileDatabase.SAND, TileDatabase.DIRT);
	public static Item GRASS_PATCH = new PlantableResource (4, "Grass Patch", "It's a patch of grass.", 2.0f, TileDatabase.WATER, TileDatabase.DIRT);
	public static Item WATER_BUCKET = new PlantableResource (5, "Bucket of Water", "Don't drown!", 2.0f, TileDatabase.WATER, TileDatabase.HOLE);
	public static Item ROCK_WALL = new PlantableResource (7, "Rock Wall", "Keeps every cunt out...", 2.0f, TileDatabase.ROCK_WALL, null);

	// INSTRUMENTS
	public static Item SHOVEL = new Instrument (3, "Shovel", "I'm gonna dig me a hole.", 0.7f, InstrumentType.SHOVEL, 30, 4, TileDatabase.DIRT, TileDatabase.GRASS, TileDatabase.SAND);
	public static Item PICKAXE = new Instrument (6, "Pickaxe", "Rock cracker...", 1.3f, InstrumentType.PICKAXE, 6, 4, TileDatabase.AIR, TileDatabase.ROCK_WALL);


	public static Item GetItemFromID (int id)
	{
		if (items[id] != null)
		{
			Item itemClone = items[id];
			return itemClone;
		}
		Debug.LogError ("Unable to retrieve item ID " + id);
		return null;
	}
}
