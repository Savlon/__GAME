using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ItemDatabase
{
	public static Item[] items = new Item[256];
	public static byte APPLE_ID = 0;
	public static byte PEAR_ID = 1;
	public static byte APPLE_SEED_ID = 2;
	public static byte SHOVEL_ID = 3;
	public static byte GRASS_PATCH_ID = 4;
	public static byte WATER_BUCKET_ID = 5;
	public static byte PICKAXE_ID = 6;
	public static byte ROCK_WALL_ID = 7;

	// FOOD
	public static Item APPLE = new Food (APPLE_ID, "Apple", "Mmmm tasty...", 2.0f, 5);
	public static Item PEAR = new Food (PEAR_ID, "Pear", "Mmmm tasty...", 2.0f, 4);

	// PLANTABLE
	public static Item APPLE_SEED = new PlantableResource (APPLE_SEED_ID, "Apple Seed", "Grows into an Apple tree.", 2.0f, 100, TileDatabase.APPLE_SEEDLING, TileDatabase.FARM);
	public static Item GRASS_PATCH = new PlantableResource (GRASS_PATCH_ID, "Grass Patch", "It's a patch of grass.", 2.0f, 0, TileDatabase.SOIL, TileDatabase.DIRT);
	public static Item WATER_BUCKET = new PlantableResource (WATER_BUCKET_ID, "Bucket of Water", "Don't drown!", 2.0f, 0, TileDatabase.SHALLOW_WATER, TileDatabase.HOLE);
	public static Item ROCK_WALL = new PlantableResource (ROCK_WALL_ID, "Rock Wall", "Keeps every cunt out...", 2.0f, 0, TileDatabase.ROCK_WALL, TileDatabase.GRASS, TileDatabase.DIRT, TileDatabase.SAND);

	// INSTRUMENTS
	public static Item SHOVEL = new Instrument (SHOVEL_ID, "Shovel", "I'm gonna dig me a hole.", 0.7f, InstrumentType.SHOVEL, 30, 4, TileDatabase.DIRT, TileDatabase.GRASS, TileDatabase.SAND);
	public static Item PICKAXE = new Instrument (PICKAXE_ID, "Pickaxe", "Rock cracker...", 1.3f, InstrumentType.PICKAXE, 6, 4, TileDatabase.AIR, TileDatabase.ROCK_WALL);


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
