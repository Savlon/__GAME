using UnityEngine;
using System.Collections;

public class Hit
{
	private Entity _source;
	private int _amount;
	private HitType _type;
	private bool _exceedMax;

	public Hit (Entity source, int amount, HitType type, bool exceedMax = false)
	{
		this._source = source;
		this._amount = amount;
		this._type = type;
		this._exceedMax = exceedMax;
	}

	public Entity Source
	{
		get {return _source;}
		set {_source = value;}
	}

	public int Amount
	{
		get {return _amount;}
		set {_amount = value;}
	}

	public HitType Type
	{
		get {return _type;}
		set {_type = value;}
	}

	public bool ExceedMax 
	{
		get {return _exceedMax;}
		set {_exceedMax = value;}
	}

	public override string ToString ()
	{
		return string.Format ("[Hit: Source={0}, Amount={1}, Type={2}, ExceedMax={3}]", Source, Amount, Type, ExceedMax);
	}
}

public enum HitType
{
	NONE,
	HEAL,
	MISSED,
	MELEE,
	RANGE,
	MAGIC
}