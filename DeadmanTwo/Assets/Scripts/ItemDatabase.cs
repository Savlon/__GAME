using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ItemDatabase
{
	public static Item[] items = new Item[256];

	/// FOOD
	public static Item APPLE = new Food (0, "Apple", "Mmmm tasty...", 2.0f, 5);
	public static Item PEAR = new Food (1, "Pear", "Mmmm tasty...", 2.0f, 4);

	/// SEEDS
	public static Item TREE_SEED = new Seed (2, "Tree Seed", "Grows into tree.", 2.0f, TileDatabase.SAND, TileDatabase.GRASS);

	// INSTRUMENTS
	public static Item SHOVEL = new Instrument (3, "Shovel", "I'm gonna dig me a hole.", 0.7f, InstrumentType.SHOVEL, 30, 4, TileDatabase.DIRT, TileDatabase.GRASS);



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
