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

	public static bool IsSamePosition (Vector2 posA, Vector2 posB)
	{
		return (FloorVector2 (posA.x, posA.y) == FloorVector2 (posB.x, posB.y));
	}

	public static bool IsSamePosition (Vector3 posA, Vector3 posB)
	{
		return (FloorVector3 (posA.x, posA.y, posA.z) == FloorVector3 (posB.x, posB.y, posB.z));
	}
}
