using UnityEngine;
using System.Collections;

public class TileLayer
{
	private int _width;
	private int _height;
	private byte[,] _tiles;
	private byte[,] _data;
	private GameObject[,] _tileObjects;

	public TileLayer (int width, int height)
	{
		_width = width;
		_height = height;
		_tiles = new byte[width, height];
		_data = new byte[width, height];
		_tileObjects = new GameObject[width, height];
	}

	public byte GetTileID (int x, int y)
	{
		if (x < 0 || y < 0 || x >= _width || y >= _height) return 255;

		return _tiles[x, y];
	}

	public byte GetTileData (int x, int y)
	{
		if (x < 0 || y < 0 || x >= _width || y >= _height) return 255;

		return _data[x, y];
	}

	public void SetTileID (int x, int y, byte id)
	{
		if (x < 0 || y < 0 || x >= _width || y >= _height) return;

		_tiles[x, y] = id;
	}

	public void SetTileData (int x, int y, byte data)
	{
		if (x < 0 || y < 0 || x >= _width || y >= _height) return;

		_data[x, y] = data;
	}

	public GameObject GetTileGameObject (int x, int y)
	{
		if (x < 0 || y < 0 || x >= _width || y >= _height) return null;

		return _tileObjects[x, y];
	}

	public void SetTileGameObject (int x, int y, GameObject tileGameObject)
	{
		if (x < 0 || y < 0 || x >= _width || y >= _height) return;

		_tileObjects[x, y] = tileGameObject;
	}

	public int Width
	{
		get {return _width;}
		private set {_width = value;}
	}

	public int Height
	{
		get {return _height;}
		private set {_height = value;}
	}
}
