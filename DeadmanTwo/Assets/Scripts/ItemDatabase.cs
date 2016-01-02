using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ItemDatabase
{
	/// FOOD
	public static Item APPLE = new Food ("Apple", "Mmmm tasty...", 5);
	public static Item PEAR = new Food ("Pear", "Mmmm tasty...", 4);

	/// SEEDS
	public static Item TREE_SEED = new Seed ("Tree Seed", "Grows into tree.", TileDatabase.SAND, TileDatabase.GRASS);

	// INSTRUMENTS
	public static Item SHOVEL = new Instrument ("Shovel", "I'm gonna dig me a hole.", InstrumentType.SHOVEL, 3, TileDatabase.DIRT, TileDatabase.GRASS);
}
