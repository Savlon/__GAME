using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Vector3Int
{
	int _x;
	int _y;
	int _z;

	public Vector3Int (int x, int y, int z)
	{
		this._x = x;
		this._y = y;
		this._z = z;
	}

	public static Vector3Int operator +(Vector3Int v3i, Vector3 v3)
	{
		int v3x = Mathf.FloorToInt (v3.x);
		int v3y = Mathf.FloorToInt (v3.y);
		int v3z = Mathf.FloorToInt (v3.z);

		return new Vector3Int (v3i.X + v3x, v3i.Y + v3y, v3i.Z + v3z);
	}

	public static Vector3Int operator -(Vector3Int v3i, Vector3 v3)
	{
		int v3x = Mathf.FloorToInt (v3.x);
		int v3y = Mathf.FloorToInt (v3.y);
		int v3z = Mathf.FloorToInt (v3.z);

		return new Vector3Int (v3i.X - v3x, v3i.Y - v3y, v3i.Z - v3z);
	}

	public static Vector3Int operator *(Vector3Int v3i, int m)
	{
		return new Vector3Int (v3i.X * m, v3i.Y * m, v3i.Z * m);
	}

	public static Vector3Int operator /(Vector3Int v3i, int d)
	{
		return new Vector3Int (v3i.X / d, v3i.Y / d, v3i.Z / d);
	}

	public static bool operator ==(Vector3Int v1, Vector3Int v3)
	{
		return ((v1.X == v3.X) && (v1.Y == v3.Y) && (v1.Z == v3.Z));
	}

	public static bool operator !=(Vector3Int v1, Vector3Int v3)
	{
		return ((v1.X != v3.X) && (v1.Y != v3.Y) && (v1.Z != v3.Z));
	}

	public static bool operator ==(Vector3Int v3i, Vector3 v3)
	{
		int v3x = Mathf.FloorToInt (v3.x);
		int v3y = Mathf.FloorToInt (v3.y);
		int v3z = Mathf.FloorToInt (v3.z);

		return ((v3i.X == v3x) && (v3i.Y == v3y) && (v3i.Z == v3z));
	}

	public static bool operator !=(Vector3Int v3i, Vector3 v3)
	{
		int v3x = Mathf.FloorToInt (v3.x);
		int v3y = Mathf.FloorToInt (v3.y);
		int v3z = Mathf.FloorToInt (v3.z);

		return ((v3i.X != v3x) && (v3i.Y != v3y) && (v3i.Z != v3z));
	}

	public static explicit operator Vector3Int(Vector3 v3)
	{
		int v3x = Mathf.FloorToInt (v3.x);
		int v3y = Mathf.FloorToInt (v3.y);
		int v3z = Mathf.FloorToInt (v3.z);

		return new Vector3Int (v3x, v3y, v3z);
	}

	public static explicit operator Vector3(Vector3Int v3i)
	{
		return new Vector3 (v3i.X, v3i.Y, v3i.Z);
	}

	public static explicit operator Vector2(Vector3Int v3i)
	{
		return new Vector2 (v3i.X, v3i.Y);
	}

	public static explicit operator Vector3Int(Vector2 v2)
	{
		int v3x = Mathf.FloorToInt (v2.x);
		int v3y = Mathf.FloorToInt (v2.y);

		return new Vector3Int (v3x, v3y, 0);
	}

	public static explicit operator Vector2Int(Vector3Int v3)
	{
		return new Vector2Int (v3.X, v3.Y);
	}

	public static explicit operator Vector3Int(Vector2Int v2)
	{
		return new Vector3Int (v2.X, v2.Y, 0);
	}

	public static float Distance (Vector3Int v1, Vector3Int v3)
	{
		return Mathf.Sqrt (Mathf.Pow (v1.X - v3.X, 2) + Mathf.Pow (v1.Y - v3.Y, 2) + Mathf.Pow (v1.Z - v3.Z, 2));
	}

	public float Magnitude ()
	{
		return Mathf.Sqrt (X * X + Y * Y + Z * Z);
	}

	public float MagnitudeSqre ()
	{
		return (X * X + Y * Y + Z * Z);
	}

	public override bool Equals (object obj)
	{
		return base.Equals (obj);
	}

	public override int GetHashCode ()
	{
		return base.GetHashCode ();
	}

	public override string ToString ()
	{
		return string.Format ("[Vector3Int: X={0}, Y={1}, Z={2}]", X, Y, Z);
	}

	public int X 
	{
		get {return _x;}
		set {_x = value;}
	}

	public int Y 
	{
		get {return _y;}
		set {_y = value;}
	}

	public int Z 
	{
		get {return _z;}
		set {_z = value;}
	}
}
