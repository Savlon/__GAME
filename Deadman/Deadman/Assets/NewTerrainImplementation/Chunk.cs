using UnityEngine;
using System.Collections;

public class Chunk : MonoBehaviour 
{
	int[,] _tiles;
	int _chunkSize = 16;
	Transform _transform;
	ChunkTileData[] _chunkTileData;

	void Awake ()
	{
		_transform = GetComponent <Transform> ();
	}

	public void Initialize (Vector3Int position, int[,] tileSection, int chunkSize)
	{
		Position = position;
		_chunkSize = chunkSize;
		_tiles = new int[_chunkSize, _chunkSize];
		_chunkTileData = new ChunkTileData[2];

		_chunkTileData[0] = new ChunkTileData (_chunkSize, _chunkSize); //base layer
		_chunkTileData[1] = new ChunkTileData (_chunkSize, _chunkSize); //overlay layer

		for (int x = 0; x < _chunkSize; x++) 
		{
			for (int y = 0; y < _chunkSize; y++) 
			{
				int id = tileSection[x, y];
				InstantiateTile (id, new Vector3Int (position.X + x, position.Y + y, position.Z));
			}
		}
	}

	public void SetTileOnLayer (float x, float y, int id, int dataValue, int layerIndex)
	{
		int xPos = Mathf.FloorToInt (x - Position.X);
		int yPos = Mathf.FloorToInt (y - Position.Y);

		if (_chunkTileData[layerIndex].GetTileGameObject (xPos, yPos) == null)
		{
			//instantiate tile if tile doesn't equal air
		}
		Debug.Log ("XPOS: " + xPos + ", YPOS: " + yPos + " - Chunk:" + Position.ToString ());
	}



	public void SetTile (int x, int y, int id)
	{
		
			
	}

	public void InstantiateTile (int id, Vector3Int position)
	{
		GameObject tileGO = Instantiate (World.Instance.tilePrefab, (Vector3)position, Quaternion.identity) as GameObject;
		tileGO.transform.SetParent (_transform, true);



		switch (id)
		{
		case 0:
			tileGO.GetComponent <SpriteRenderer> ().color = Color.green;
			break;
		case 1:
			tileGO.GetComponent <SpriteRenderer> ().color = Color.red;
			break;
		case 2:
			tileGO.GetComponent <SpriteRenderer> ().color = Color.yellow;
			break;
		case 3:
			tileGO.GetComponent <SpriteRenderer> ().color = Color.blue;
			break;
		case 4:
			tileGO.GetComponent <SpriteRenderer> ().color = Color.black;
			break;
		case 5:

			break;
		case 6:

			break;
		}
		//SetTile (position.X, position.Y, id);
	}

	public Vector3Int Position
	{
		get {return (Vector3Int)_transform.position;}
		set {_transform.position = (Vector3)value;}
	}

	public int ChunkSize
	{
		get {return _chunkSize;}
		set {_chunkSize = value;}
	}
}
