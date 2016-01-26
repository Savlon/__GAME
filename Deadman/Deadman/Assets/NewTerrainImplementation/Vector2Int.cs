using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Vector2Int
{
	int _x;
	int _y;

	public Vector2Int (int x, int y)
	{
		this._x = x;
		this._y = y;
	}

	public static Vector2Int operator +(Vector2Int v2i, Vector2 v2)
	{
		int v2x = Mathf.FloorToInt (v2.x);
		int v2y = Mathf.FloorToInt (v2.y);

		return new Vector2Int (v2i.X + v2x, v2i.Y + v2y);
	}

	public static Vector2Int operator -(Vector2Int v2i, Vector2 v2)
	{
		int v2x = Mathf.FloorToInt (v2.x);
		int v2y = Mathf.FloorToInt (v2.y);

		return new Vector2Int (v2i.X - v2x, v2i.Y - v2y);
	}

	public static Vector2Int operator *(Vector2Int v2i, int m)
	{
		return new Vector2Int (v2i.X * m, v2i.Y * m);
	}

	public static Vector2Int operator /(Vector2Int v2i, int d)
	{
		return new Vector2Int (v2i.X / d, v2i.Y / d);
	}

	public static bool operator ==(Vector2Int v1, Vector2Int v2)
	{
		return ((v1.X == v2.X) && (v1.Y == v2.Y));
	}

	public static bool operator !=(Vector2Int v1, Vector2Int v2)
	{
		return ((v1.X != v2.X) && (v1.Y != v2.Y));
	}

	public static bool operator ==(Vector2Int v2i, Vector2 v2)
	{
		int v2x = Mathf.FloorToInt (v2.x);
		int v2y = Mathf.FloorToInt (v2.y);

		return ((v2i.X == v2x) && (v2i.Y == v2y));
	}

	public static bool operator !=(Vector2Int v2i, Vector2 v2)
	{
		int v2x = Mathf.FloorToInt (v2.x);
		int v2y = Mathf.FloorToInt (v2.y);

		return ((v2i.X != v2x) && (v2i.Y != v2y));
	}

	public static explicit operator Vector2Int(Vector2 v2)
	{
		int v2x = Mathf.FloorToInt (v2.x);
		int v2y = Mathf.FloorToInt (v2.y);

		return new Vector2Int (v2x, v2y);
	}

	public static explicit operator Vector2(Vector2Int v2i)
	{
		return new Vector2 (v2i.X, v2i.Y);
	}

	public static explicit operator Vector3(Vector2Int v2i)
	{
		return new Vector3 (v2i.X, v2i.Y, 0);
	}

	public static explicit operator Vector2Int(Vector3 v3)
	{
		int v2x = Mathf.FloorToInt (v3.x);
		int v2y = Mathf.FloorToInt (v3.y);

		return new Vector2Int (v2x, v2y);
	}

	public static float Distance (Vector2Int v1, Vector2Int v2)
	{
		return Mathf.Sqrt (Mathf.Pow (v1.X - v2.X, 2) + Mathf.Pow (v1.Y - v2.Y, 2));
	}
		
	public float Magnitude ()
	{
		return Mathf.Sqrt (X * X + Y * Y);
	}

	public float MagnitudeSqre ()
	{
		return (X * X + Y * Y);
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
		return string.Format ("[Vector2Int: X={0}, Y={1}]", X, Y);
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
}
