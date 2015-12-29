using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour 
{
	//TEST
	public Entity referenceEntityPrefab;
	public GameObject referenceTilePrefab;
	public int level;
	//TEST

	private int width = 100;
	private int height = 100;

	private List <Entity> _entitiesInGame;
	private List <Entity>[,] _entitiesInTiles;

	private byte[,] _tiles;
	private byte[,] _data;

	private GameObject[,] _tileObjects;
	
	void Start () 
	{
		_entitiesInGame = new List<Entity> ();

		_tiles = new byte[width, height];
		_data = new byte[width, height];
		_tileObjects = new GameObject[width, height];

		_entitiesInTiles = new List<Entity>[width, height];
		for (int x = 0; x < _entitiesInTiles.GetLength (0); x++)
			for (int y = 0; y < _entitiesInTiles.GetLength (1); y++)
				_entitiesInTiles[x, y] = new List<Entity> ();


		for (int y = 0; y < _tiles.GetLength (1); y++)
		{
			for (int x = 0; x < _tiles.GetLength (0); x++)
			{
				if (_tileObjects[x, y] == null)
				{
					GameObject tile = Instantiate (referenceTilePrefab, new Vector3 (x, y, level), Quaternion.identity) as GameObject;
					_tileObjects[x, y] = tile;
					tile.transform.SetParent (gameObject.transform, true);
				}
			}
		}

		for (int y = 0; y < _tiles.GetLength (1); y++)
		{
			for (int x = 0; x < _tiles.GetLength (0); x++)
			{
				SetTile ((float)x, (float)y, TileDatabase.Clone (TileDatabase.GRASS, new Vector3 (x, y, level)), 0);
			}
		}
	}

	private float timer;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			for (int y = 0; y < _tiles.GetLength (1); y++)
			{
				for (int x = 0; x < _tiles.GetLength (0); x++)
				{
					int rng = Random.Range (0, 4);

//					if (x == 0 || y == 0 || x >= _tiles.GetLength (0) - 1 || y >= _tiles.GetLength (1) - 1)
//						rng = 3;

					Tile clonedTile = TileDatabase.Clone (TileDatabase.tiles[rng], new Vector3 (x, y, 0));
					SetTile ((float)x, (float)y, clonedTile, 0);
				}
			}

		}


		timer -= Time.deltaTime;

		if (timer <= 0)
		{
			timer = 4 * Time.deltaTime;

			for (int y = 0; y < _tiles.GetLength (1); y++)
			{
				for (int x = 0; x < _tiles.GetLength (0); x++)
				{
					GetTile ((float)x, (float)y).UpdateImage (this, x, y);
				}
			}
		}
		

//		//TEST
//		if (Input.GetKeyDown (KeyCode.A))
//		{
//			Add (referenceEntityPrefab, 0, 0);
//			SetData (0.0f, 0.0f, 3999);
//			Debug.Log ("[GAME] Data: " + GetData (0.0f, 0.0f));
//		}
////
//		if (Input.GetKeyDown (KeyCode.R))
//		{
//			Entity randomEntity = _entitiesInGame [Random.Range (0, _entitiesInGame.Count)];
//			randomEntity.Remove = true;
//		}
//
//		if (Input.GetKeyDown (KeyCode.Space))
//		{
//			List <Entity> entitiesInArea = GetEntitiesInArea (1, 1, 1, 1);
//			Debug.Log ("[AREA] Entity Count = " + entitiesInArea.Count);
//		}
//		//TEST

		for (int i = 0; i < width * height / 50; i++)
		{
			float xt = Random.Range (0, width);
			float yt = Random.Range (0, height);
			GetTile (xt, yt).Update (this, (int)xt, (int)yt);
		}

//		for (int y = 0; y < _tiles.GetLength (1); y++)
//		{
//			for (int x = 0; x < _tiles.GetLength (0); x++)
//			{
//				Tile tile = GetTile ((float)x, (float)y);
//
//				tile.UpdateImage (this, x, y);
//			}
//		}


		for (int i = 0; i < _entitiesInGame.Count; i++)
		{
			Entity entity = _entitiesInGame [i];
			if (entity.Remove)
			{
				Remove (entity);
			}
		}
	}


	public Tile GetTile (float x, float y)
	{
		int xPos = Mathf.FloorToInt (x);
		int yPos = Mathf.FloorToInt (y);

		if (xPos < 0 || xPos >= width || yPos < 0 || yPos >= height) return TileDatabase.ROCK;
		return TileDatabase.tiles[_tiles [xPos, yPos]];
	}

	public void SetTile (float x, float y, Tile tile, int dataValue)
	{
		int xPos = Mathf.FloorToInt (x);
		int yPos = Mathf.FloorToInt (y);
		
		if (xPos < 0 || xPos >= width || yPos < 0 || yPos >= height) return;

		_tiles[xPos, yPos] = tile.ID;
		_tileObjects[xPos, yPos].GetComponent <SpriteRenderer> ().sprite = tile.Image;
		_data[xPos, yPos] = (byte)dataValue;
	}

	public int GetData (float x, float y)
	{
		int xPos = Mathf.FloorToInt (x);
		int yPos = Mathf.FloorToInt (y);
		
		if (xPos < 0 || xPos >= width || yPos < 0 || yPos >= height) return 0;

		return _data[xPos, yPos] & 0xff;
	}

	public void SetData (float x, float y, int value)
	{
		int xPos = Mathf.FloorToInt (x);
		int yPos = Mathf.FloorToInt (y);
		
		if (xPos < 0 || xPos >= width || yPos < 0 || yPos >= height) return;

		_data[xPos, yPos] = (byte)value;
	}

	public void Add (Entity referenceEntity, int x, int y)
	{
		Entity entity = Instantiate (referenceEntity, new Vector3 ((float)x, (float)y, 0), Quaternion.identity) as Entity;
		_entitiesInGame.Add (entity);
		entity.Initialize (this);
		InsertEntity (entity.Position.x, entity.Position.y, entity);
	}

	public void Remove (Entity entity)
	{
		_entitiesInGame.Remove (entity);
		RemoveEntity (entity.Position.x, entity.Position.y, entity);
		Destroy (entity.gameObject);
	}

	private void InsertEntity (float x, float y, Entity entity)
	{
		int xPos = Mathf.FloorToInt (x);
		int yPos = Mathf.FloorToInt (y);
		
		if (xPos < 0 || xPos >= width || yPos < 0 || yPos >= height) return;

		_entitiesInTiles[xPos, yPos].Add (entity);
	}

	private void RemoveEntity (float x, float y, Entity entity)
	{
		int xPos = Mathf.FloorToInt (x);
		int yPos = Mathf.FloorToInt (y);
		
		if (xPos < 0 || xPos >= width || yPos < 0 || yPos >= height) return;

		_entitiesInTiles[xPos, yPos].Remove (entity);
	}

	public List <Entity> GetEntitiesInArea (int bottomLeft, int topLeft, int topRight, int bottomRight)
	{
		List <Entity> result = new List<Entity> ();
		for (int x = bottomLeft; x <= bottomRight; x++)
		{
			for (int y = topLeft; y <= topRight; y++)
			{
				if (x < 0 || x >= width || y < 0 || y >= height) continue;
				
				List <Entity> entities = _entitiesInTiles [x, y];
				for (int i = 0; i < entities.Count; i++)
				{
					Entity entity = entities [i];
					if (result.Contains (entity)) continue;
					
					result.Add (entity);
				}
			}
		}
		return result;
	}
}























