using UnityEngine;
using System.Collections;

public static class Utils
{

	public static Vector2 FloorVector2 (float x, float y)
	{
		return new Vector2 (Mathf.FloorToInt (x), Mathf.FloorToInt (y));
	}

	public static Vector3 FloorVector3 (float x, float y, float z)
	{
		return new Vector3 (Mathf.FloorToInt (x), Mathf.FloorToInt (y), Mathf.FloorToInt (z));
	}
}
