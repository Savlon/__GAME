using UnityEngine;
using System.Collections;

public class Hitpoints
{
	private int _current;
	private int _maximum;

	public Hitpoints ()
	{
		this._maximum = 1;
		this._current = _maximum;
	}

	public Hitpoints (int maximum)
	{
		this._maximum = maximum;
		this._current = maximum;
	}

	public Hitpoints (int maximum, int current)
	{
		this._maximum = maximum;
		this._current = current;
	}

	public int Current
	{
		get {return this._current;}
		set {this._current = value;}
	}

	public int Maximum
	{
		get {return this._maximum;}
		set {this._maximum = value;}
	}

	public void Remove (int amount)
	{
		this._current -= amount;

		if (this._current < 0)
			this._current = 0;
	}

	public void Add (int amount, bool exceedMax = false)
	{
		this._current += amount;

		if (this._current > this._maximum)
		{
			if (!exceedMax)
			{
				this._current = this._maximum;
			}
		}
	}

	public override string ToString ()
	{
		return string.Format ("[Hitpoints: Current={0}, Maximum={1}]", Current, Maximum);
	}
}