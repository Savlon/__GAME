using UnityEngine;
using System.Collections;
using TinkerWorX.AccidentalNoiseLibrary;

public class Generator : MonoBehaviour 
{
	public FractalType fractalType;
	public BasisType basisType;
	public InterpolationType interpolationType;
	public float frequency;
	public int octaves;
	public string seed;

	ImplicitFractal heightMap;

	void Start () 
	{
		heightMap = new ImplicitFractal (fractalType, basisType, interpolationType);
		heightMap.Frequency = frequency;
		heightMap.Octaves = octaves;
		heightMap.Seed = StringToInt (seed);
	}

	public ChunkData GetChunkData (Chunk chunk)
	{
		ChunkData chunkData = new ChunkData (chunk.ChunkSize, chunk.ChunkSize);

		for (int y = 0; y < chunkData.Data.GetLength (1); y++) 
		{
			for (int x = 0; x < chunkData.Data.GetLength (0); x++) 
			{
				float x1 = ((float)chunk.Position.X + (float)x) / (float)chunkData.Data.GetLength (0);
				float y1 = ((float)chunk.Position.Y + (float)y) / (float)chunkData.Data.GetLength (1);

				float value = (float)heightMap.Get (x1, y1);

				if (value > chunkData.Max) chunkData.Max = value;
				if (value < chunkData.Min) chunkData.Min = value;

				//normalize value between 0 and 1
				value = (value - chunkData.Min) / (chunkData.Max - chunkData.Min);

				chunkData.Data [x, y] = value;
			}
		}

		return chunkData;
	}

	private int StringToInt (string s)
	{
		int result = 0;
		char[] chars = s.ToCharArray ();

		for (int i = 0; i < chars.Length; i++)
		{
			result += (int)chars[i];
		}
		return result;
	}

}
