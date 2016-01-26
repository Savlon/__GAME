using UnityEngine;
using System.Collections;

public class ChunkData
{
	float[,] _data;
	float _min;
	float _max;

	public ChunkData (int width, int height)
	{
		_data = new float[width, height];
		_min = float.MaxValue;
		_max = float.MinValue;
	}

	public float[,] Data
	{
		get {return _data;}
		set {_data = value;}
	}

	public float Min
	{
		get {return _min;}
		set {_min = value;}
	}

	public float Max
	{
		get {return _max;}
		set {_max = value;}
	}
}

