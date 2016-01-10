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

	private int width = 10;
	private int height = 10;

	private List <Entity> _entitiesInGame;
	private List <Entity>[,] _entitiesInTiles;

//	private byte[,] _tiles;
//	private byte[,] _data;
//
//	private GameObject[,] _tileObjects;

	private TileLayer[] _tileLayers;

	private TileLayer _baseLayer;
	private TileLayer _overlayLayer;

	void Start () 
	{
		_entitiesInGame = new List<Entity> ();


		_baseLayer = new TileLayer (width, height);
		_overlayLayer = new TileLayer (width, height);

		_tileLayers = new TileLayer[2];
		_tileLayers[0] = _baseLayer;
		_tileLayers[1] = _overlayLayer;

		_entitiesInTiles = new List<Entity>[width, height];
		for (int x = 0; x < _entitiesInTiles.GetLength (0); x++)
			for (int y = 0; y < _entitiesInTiles.GetLength (1); y++)
				_entitiesInTiles[x, y] = new List<Entity> ();


//		for (int y = 0; y < _baseLayer.Height; y++)
//		{
//			for (int x = 0; x < _baseLayer.Width; x++)
//			{
//				if (_baseLayer.GetTileGameObject (x, y) == null)
//				{
//					GameObject tile = Instantiate (referenceTilePrefab, new Vector3 (x, y, level), Quaternion.identity) as GameObject;
//					_baseLayer.SetTileGameObject (x, y, tile);
//					tile.transform.SetParent (gameObject.transform, true);
//				}
//			}
//		}

		for (int y = 0; y < _baseLayer.Height; y++)
		{
			for (int x = 0; x < _baseLayer.Width; x++)
			{
//				SetTile ((float)x, (float)y, TileDatabase.Clone (TileDatabase.GRASS, new Vector3 (x, y, level)), 0);
				SetTileOnLayer ((float)x, (float)y, TileDatabase.Clone (TileDatabase.GRASS, new Vector3 (x, y, 0)), 0, 0);
			}
		}
	}

	private float timer;

	private int oldEX;
	private int oldEY;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			SetTile (1, 1, TileDatabase.ROCK, 0);
			SetTile (1, 2, TileDatabase.ROCK, 0);

			Debug.Log ("Tile At 1, 1 " + GetTileOnLayer (1f, 1f, 0).ID );
			Debug.Log ("Tile At 1, 1 " + GetTileOnLayer (1f, 1f, 1).ID );
//			for (int p = _tileLayers.Length - 1; p >= 0; p--)
//			{
//				Debug.Log (p);
//				if (_tileLayers[p].GetTileGameObject (0, 0) == null)
//				{
//					GameObject tile = Instantiate (referenceTilePrefab, new Vector3 (0, 0, level), Quaternion.identity) as GameObject;
//					_tileLayers[p].SetTileGameObject (0, 0, tile);
//					tile.transform.SetParent (gameObject.transform, true);
//				}
//			}
		}

		if (Input.GetKeyDown (KeyCode.Y))
		{
			SetTile (1, 1, TileDatabase.AIR, 0);
		}

//		if (Input.GetKeyDown (KeyCode.Space))
//		{
//			for (int y = 0; y < _tiles.GetLength (1); y++)
//			{
//				for (int x = 0; x < _tiles.GetLength (0); x++)
//				{
//					int rng = Random.Range (0, 4);
//
////					if (x == 0 || y == 0 || x >= _tiles.GetLength (0) - 1 || y >= _tiles.GetLength (1) - 1)
////						rng = 3;
//
//					Tile clonedTile = TileDatabase.Clone (TileDatabase.tiles[rng], new Vector3 (x, y, 0));
//					SetTile ((float)x, (float)y, clonedTile, 0);
//				}
//			}
//
//		}


		timer -= Time.deltaTime;

		if (timer <= 0)
		{
			timer = 4 * Time.deltaTime;

			for (int x = 0; x < width; x++) {
				for (int y = 0; y < height; y++) {
					if (GetTileOnLayer ((float)x, (float)y, 1) != TileDatabase.AIR)
						GetTileOnLayer ((float)x, (float)y, 1).UpdateImage (this, x, y);

					GetTileOnLayer ((float)x, (float)y, 0).UpdateImage (this, x, y);
				}
			}

//			for (int y = 0; y < _baseLayer.Height; y++)
//			{
//				for (int x = 0; x < _baseLayer.Width; x++)
//				{
//					for (int i = 0; i < _tileLayers.Length; i++) {
//						Tile t = GetTileOnLayer ((float)x, (float)y, i);
//						if (t.ID != TileDatabase.AIR.ID)
//							t.UpdateImage (this, x, y);
//						//.UpdateImage (this, x, y);
//					}
////					GetTile ((float)x, (float)y).UpdateImage (this, x, y);
//				}
//			}
		}
		

//		//TEST
		if (Input.GetKeyDown (KeyCode.Q))
		{
			Add (referenceEntityPrefab, 5, 5);
		}
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

		for (int i = 0; i < _entitiesInGame.Count; i++) {
			Entity e = _entitiesInGame[i];

			int eX = Mathf.FloorToInt (e.Position.x);
			int eY = Mathf.FloorToInt (e.Position.y);

			if (eX != e._oldXPosition || eY != e._oldYPosition)
			{
				RemoveEntity (e._oldXPosition, e._oldYPosition, e);
				InsertEntity (eX, eY, e);
				e._oldXPosition = eX;
				e._oldYPosition = eY;
			}
		}

		for (int i = 0; i < _entitiesInGame.Count; i++)
		{
			Entity entity = _entitiesInGame [i];
			if (entity.Remove)
			{
				Remove (entity);
			}
		}
	}

	public Tile GetTileOnLayer (float x, float y, int layerIndex)
	{
		int xPos = Mathf.FloorToInt (x);
		int yPos = Mathf.FloorToInt (y);
		
		if (xPos < 0 || xPos >= width || yPos < 0 || yPos >= height) return TileDatabase.ROCK;

		int index = _tileLayers[layerIndex].GetTileID (xPos, yPos);

		return TileDatabase.tiles[index];
	}

	//TODO: Make it so that each tile holds a variable to say whether it is a base layer tile or
	//		an overlay tile (grass = base, bush/shrub = overlay)
	public Tile GetTile (float x, float y)
	{
		int xPos = Mathf.FloorToInt (x);
		int yPos = Mathf.FloorToInt (y);

		if (xPos < 0 || xPos >= width || yPos < 0 || yPos >= height) return TileDatabase.ROCK;

		int tId = 255;

		for (int layerIndex = _tileLayers.Length - 1; layerIndex >= 0; layerIndex--) 
		{
			if (_tileLayers[layerIndex].GetTileID (xPos, yPos) != TileDatabase.AIR.ID)
			{
				tId = _tileLayers[layerIndex].GetTileID (xPos, yPos);
			}
		}

		return TileDatabase.tiles[tId];
	}

	public void SetTileOnLayer (float x, float y, Tile tile, int dataValue, int layerIndex)
	{
		int xPos = Mathf.FloorToInt (x);
		int yPos = Mathf.FloorToInt (y);
		
		if (xPos < 0 || xPos >= width || yPos < 0 || yPos >= height) return;


		if (_tileLayers[layerIndex].GetTileGameObject (xPos, yPos) == null)
		{
			if (_tileLayers[layerIndex].GetTileID (xPos, yPos) != TileDatabase.AIR.ID ||
			    (layerIndex == 0))
			{
				GameObject newTileGO = Instantiate (referenceTilePrefab, new Vector3 (xPos, yPos, layerIndex), Quaternion.identity) as GameObject;
				newTileGO.transform.SetParent (gameObject.transform, true);
				_tileLayers[layerIndex].SetTileGameObject (xPos, yPos, newTileGO);
			}
		}
		else
		{
			if (_tileLayers[layerIndex].GetTileID (xPos, yPos) == TileDatabase.AIR.ID)
			{
				GameObject deleteReference = _tileLayers[layerIndex].GetTileGameObject (xPos, yPos);
				_tileLayers[layerIndex].SetTileGameObject (xPos, yPos, null);
				Destroy (deleteReference);
			}
		}
			
		if (layerIndex == 0 && tile.IsBaseTile)
		{
			_tileLayers[layerIndex].SetTileID (xPos, yPos, tile.ID);
			_tileLayers[layerIndex].SetTileData (xPos, yPos, (byte)dataValue);
			_tileLayers[layerIndex].GetTileGameObject (xPos, yPos).GetComponent <SpriteRenderer> ().sprite = tile.Image;
			return;
		}

		if (layerIndex == 1 && !tile.IsBaseTile)
		{
			_tileLayers[layerIndex].SetTileID (xPos, yPos, tile.ID);
			_tileLayers[layerIndex].SetTileData (xPos, yPos, (byte)dataValue);
			_tileLayers[layerIndex].GetTileGameObject (xPos, yPos).GetComponent <SpriteRenderer> ().sprite = tile.Image;

			return;
		}
	}

	public void SetTile (float x, float y, Tile tile, int dataValue)
	{
		int xPos = Mathf.FloorToInt (x);
		int yPos = Mathf.FloorToInt (y);
		
		if (xPos < 0 || xPos >= width || yPos < 0 || yPos >= height) return;

		// IF TOP LAYER IS AIR
		if (_tileLayers[1].GetTileID (xPos, yPos) == TileDatabase.AIR.ID)
		{
			// IF DESIRED TILE IS NOT A BASE TILE
			if (!tile.IsBaseTile)
			{
				// IF TOP LAYER DOESN'T HAVE A GAMEOBJECT
				if (_tileLayers[1].GetTileGameObject (xPos, yPos) == null)
				{
					// CREATE A NEW TILE GAMEOBJECT
					GameObject newTileGO = Instantiate (referenceTilePrefab, new Vector3 (xPos, yPos, -1), Quaternion.identity) as GameObject;
					newTileGO.transform.SetParent (gameObject.transform, true);
					_tileLayers[1].SetTileGameObject (xPos, yPos, newTileGO);
				}

				_tileLayers[1].GetTileGameObject (xPos, yPos).GetComponent <SpriteRenderer> ().sprite = tile.Image;
				_tileLayers[1].SetTileID (xPos, yPos, tile.ID);
				_tileLayers[1].SetTileData (xPos, yPos, (byte)dataValue);
			}
			else if (tile.IsBaseTile)
			{
				if (_tileLayers[1].GetTileGameObject (xPos, yPos) != null)
				{
					GameObject deleteReferenceGO = _tileLayers[1].GetTileGameObject (xPos, yPos);
					_tileLayers[1].SetTileGameObject (xPos, yPos, null);
					Destroy (deleteReferenceGO);
				}

				_tileLayers[0].SetTileID (xPos, yPos, tile.ID);
				_tileLayers[0].SetTileData (xPos, yPos, (byte)dataValue);
				_tileLayers[0].GetTileGameObject (xPos, yPos).GetComponent <SpriteRenderer> ().sprite = tile.Image;
			}
		}
		else
		{
			if (tile.ID == TileDatabase.AIR.ID)
			{
				_tileLayers[1].SetTileID (xPos, yPos, tile.ID);
				_tileLayers[1].SetTileData (xPos, yPos, (byte)dataValue);

				GameObject deleteReferenceGO = _tileLayers[1].GetTileGameObject (xPos, yPos);
				_tileLayers[1].SetTileGameObject (xPos, yPos, null);
				Destroy (deleteReferenceGO);
				return;
			}

			if (!tile.IsBaseTile)
			{
				_tileLayers[1].SetTileID (xPos, yPos, tile.ID);
				_tileLayers[1].SetTileData (xPos, yPos, (byte)dataValue);
				_tileLayers[1].GetTileGameObject (xPos, yPos).GetComponent <SpriteRenderer> ().sprite = tile.Image;
			}
		}
	}

	public int GetData (float x, float y)
	{
		int xPos = Mathf.FloorToInt (x);
		int yPos = Mathf.FloorToInt (y);
		
		if (xPos < 0 || xPos >= width || yPos < 0 || yPos >= height) return 0;

		int tData = _baseLayer.GetTileData (xPos, yPos);

		return tData & 0xff;
	}

	public void SetData (float x, float y, int value)
	{
		int xPos = Mathf.FloorToInt (x);
		int yPos = Mathf.FloorToInt (y);
		
		if (xPos < 0 || xPos >= width || yPos < 0 || yPos >= height) return;

		_baseLayer.SetTileData (xPos, yPos, (byte)value);
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
		entity.Finalize (this);
		Destroy (entity.gameObject);
	}

	private void InsertEntity (float x, float y, Entity entity)
	{
		int xPos = Mathf.FloorToInt (x);
		int yPos = Mathf.FloorToInt (y);
		
		if (xPos < 0 || xPos >= width || yPos < 0 || yPos >= height) return;

		if (!_entitiesInTiles[xPos, yPos].Contains (entity))
			_entitiesInTiles[xPos, yPos].Add (entity);
	}

	private void RemoveEntity (float x, float y, Entity entity)
	{
		int xPos = Mathf.FloorToInt (x);
		int yPos = Mathf.FloorToInt (y);
		
		if (xPos < 0 || xPos >= width || yPos < 0 || yPos >= height) return;

		if (_entitiesInTiles[xPos, yPos].Contains (entity))
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























