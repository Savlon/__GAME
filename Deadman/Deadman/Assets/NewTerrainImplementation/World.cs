using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour 
{
	public GameObject tilePrefab;
	public Chunk chunkPrefab;
	public int chunkSize;

	Dictionary <Vector3Int, Chunk> chunks;
	Generator generator;

	private static World _instance;

	void Start () 
	{
		chunks = new Dictionary<Vector3Int, Chunk> ();
		generator = GetComponent <Generator> ();

		for (int x = -chunkSize; x < chunkSize; x += chunkSize)
		{
			for (int y = -chunkSize; y < chunkSize; y += chunkSize)
			{
				InstantiateChunk (chunkPrefab, (Vector3Int)new Vector3 (x, y, transform.position.z));
			}
		}
	}
		
	void Update () 
	{
		Vector3Int cameraPosition = (Vector3Int)Camera.main.transform.position;
		Vector3Int flooredCameraPosition = new Vector3Int ((cameraPosition.X / chunkSize) * chunkSize, (cameraPosition.Y / chunkSize) * chunkSize, cameraPosition.Z);

		for (int x = -10; x < 10; x++)
		{
			for (int y = -10; y < 10; y++)
			{
				
				Vector3Int checkPosition = new Vector3Int (x * chunkSize + flooredCameraPosition.X, y * chunkSize + flooredCameraPosition.Y, Mathf.FloorToInt (transform.position.z));

				if (Mathf.Abs (x) <= 2 && Mathf.Abs (y) <= 2)
				{
					if (x > 1 || y > 1)
						continue;
					
					if (!chunks.ContainsKey (checkPosition))
					{
//						int[,] tileSection = new int[chunkSize, chunkSize];
						InstantiateChunk (chunkPrefab, checkPosition);
						continue;
					}
				}
				else
				{
					if (chunks.ContainsKey (checkPosition))
					{
						DestroyChunk (checkPosition);
					}
				}
			}
		}

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePosition.z = 0;

		if (Input.GetMouseButtonDown (0))
		{
			Vector3Int overPosition = (Vector3Int)(mousePosition / chunkSize) * chunkSize;

			Debug.Log (overPosition.ToString ());
			Chunk overChunk = chunks[overPosition];
			overChunk.SetTileOnLayer (mousePosition.x, mousePosition.y, 1, 0, 0);
		}
	}


	public void InstantiateChunk (Chunk chunkPrefab, Vector3Int position)
	{
		if (!chunks.ContainsKey (position))
		{
			Chunk newChunk = Instantiate (chunkPrefab, new Vector3 (position.X, position.Y, position.Z), Quaternion.identity) as Chunk;
			newChunk.transform.SetParent (transform, true);
			newChunk.gameObject.name = position.ToString ();
			int[,] tileSection = LoadChunkData (newChunk);

			newChunk.Initialize ((Vector3Int)newChunk.transform.position, tileSection, chunkSize);
			chunks.Add (position, newChunk);
		}
	}

	int [,] LoadChunkData (Chunk chunk)
	{
		ChunkData chunkData = generator.GetChunkData (chunk);
		int[,] data = new int[chunkData.Data.GetLength (0), chunkData.Data.GetLength (1)];

		for (int y = 0; y < data.GetLength (1); y++) 
		{
			for (int x = 0; x < data.GetLength (0); x++) 
			{
				float value = chunkData.Data[x, y];
				int tileID;

				if (value < 0.2f)
					tileID = 3;
				else if (value < 0.3f)
					tileID = 2;
				else if (value < 0.4f)
					tileID = 1;
				else
					tileID = 0;

				data[x, y] = tileID;
			}
		}
		return data;
	}

	public void DestroyChunk (Vector3Int position)
	{
		if (chunks.ContainsKey (position))
		{
			Chunk chunk = chunks[position];
			chunks.Remove (position);
			Destroy (chunk.gameObject);
			Debug.Log ("destroying chunk");
		}
	}

	public static World Instance
	{
		get 
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType <World> ();
			}
			return _instance;
		}
	}
}
