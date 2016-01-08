using UnityEngine;
using System.Collections;

public class KeyInput
{
	private string _horizontalAxis;
	private string _verticalAxis;

	public KeyInput (string horizontalAxis, string verticalAxis)
	{
		this._horizontalAxis = horizontalAxis;
		this._verticalAxis = verticalAxis;
	}

	public void Update (IMovable entity)
	{
		if (!IsFrozen (entity))
		{
			entity.Move (Input.GetAxisRaw (_horizontalAxis), Input.GetAxisRaw (_verticalAxis));
		}
	}

	public bool IsFrozen (IMovable entity)
	{
		return entity.Frozen;
	}

	public string HorizontalAxis
	{
		get {return _horizontalAxis;}
		set {_horizontalAxis = value;}
	}

	public string VerticalAxis
	{
		get {return _verticalAxis;}
		set {_verticalAxis = value;}
	}
}
