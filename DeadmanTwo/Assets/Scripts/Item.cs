using UnityEngine;
using System.Collections;

public class Item
{
	private string _name;
	private string _description;

	public Item () : this ("NULL", "NULL")
	{
	}

	public Item (string name, string description)
	{
		this._name = name;
		this._description = description;
	}

	public virtual bool InteractOn (Tile tile, Level level, int x, int y, Player player)
	{
		return false;
	}

	public virtual bool Interact (Player player, Entity entity)
	{
		return false;
	}

	public virtual bool Use (Player player)
	{
		return false;
	}

	public string Name
	{
		get {return _name;} set {_name = value;}
	}

	public string Description
	{
		get {return _description;} set {_description = value;}
	}
}
