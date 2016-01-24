using UnityEngine;
using System.Collections;
using TinkerWorX.AccidentalNoiseLibrary;

public class Generator : MonoBehaviour
{

	public FractalType fractalType = FractalType.Multi;
	public BasisType basisType = BasisType.Simplex;
	public InterpolationType interpolationType = InterpolationType.Quintic;
	public int terrainOctaves = 6;
	public double terrainFrequency = 1.25;
	public string seed = "map";

	private ImplicitFractal heightMap;
	private MapData heightData;


	void Awake ()
	{
		heightMap = new ImplicitFractal (fractalType, basisType, interpolationType);
		heightMap.Octaves = terrainOctaves;
		heightMap.Frequency = terrainFrequency;
		heightMap.Seed = StringToInt (seed);
	}

	public void LoadGenerationData (int width, int height)
	{
		heightData = new MapData (width, height);

		for (int y = 0; y < height; y++) 
		{
			for (int x = 0; x < width; x++) 
			{
				float x1 = x / (float)width;
				float y1 = y / (float)height;

				float value = (float)heightMap.Get (x1, y1);

				if (value > heightData.Max) heightData.Max = value;
				if (value < heightData.Min) heightData.Min = value;

				//normalize value between 0-1
				value = (value - heightData.Min) / (heightData.Max - heightData.Min);

				heightData.Data [x, y] = value;
			}
		}
	}

	public float GetData (int x, int y)
	{
		return heightData.Data [x, y];
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

