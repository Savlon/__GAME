using UnityEngine;
using System.Collections;

public class ChunkTileData
{
	int width;
	int height;
	byte[,] tiles;
	byte[,] data;
	GameObject[,] tileObjects;

	public ChunkTileData (int width, int height)
	{
		this.width = width;
		this.height = height;
		tiles = new byte[width, height];
		data = new byte[width, height];
		tileObjects = new GameObject[width, height];

		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				tiles[x, y] = 255; //FIXME: SET THIS TO AIR TILE ID
				data[x, y] = 0;
			}
		}
	}

	public byte GetTileID (int x, int y)
	{
		if (x < 0 || y < 0 || x >= width || y >= height)
			return 255;

		return tiles[x, y];
	}

	public void SetTileID (int x, int y, byte id)
	{
		if (x < 0 || y < 0 || x >= width || y >= height)
			return;

		tiles[x, y] = id;
	}

	public byte GetTileData (int x, int y)
	{
		if (x < 0 || y < 0 || x >= width || y >= height)
			return 0;

		return data[x, y];
	}

	public void SetTileData (int x, int y, byte value)
	{
		if (x < 0 || y < 0 || x >= width || y >= height)
			return;

		data[x, y] = value;
	}

	public GameObject GetTileGameObject (int x, int y)
	{
		if (x < 0 || y < 0 || x >= width || y >= height)
			return null;

		return tileObjects[x, y];
	}

	public void SetTileGameObject (int x, int y, GameObject tileGameObject)
	{
		if (x < 0 || y < 0 || x >= width || y >= height)
			return;

		tileObjects[x, y] = tileGameObject;
	}

	public int Width
	{
		get {return width;}
		private set {width = value;}
	}

	public int Height
	{
		get {return height;}
		private set {height = value;}
	}
}

