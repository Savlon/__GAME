using UnityEngine;
using System.Collections;

public class Item
{
	private int _id;
	private string _name;
	private string _description;
	private float _delay;
	private Sprite _image;

	public Item () : this (-1, "NULL", "NULL", 3.0f)
	{
	}

	public Item (int id, string name, string description, float delay)
	{
		this._id = id;
		this._name = name;
		this._description = description;
		this._delay = delay;
		this._image = Resources.LoadAll <Sprite> ("Items/Weapons")[id];

		if (ItemDatabase.items[id] != null && id != -1)
			Debug.LogError ("Item " + name + " has a duplicate ID of " + id);

		ItemDatabase.items[id] = this;
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

	public int ID
	{
		get {return _id;} set {_id = value;}
	}

	public float Delay
	{
		get {return _delay;} set {_delay = value;}
	}

	public string Name
	{
		get {return _name;} set {_name = value;}
	}

	public string Description
	{
		get {return _description;} set {_description = value;}
	}

	public Sprite Image
	{
		get {return _image;} set {_image = value;}
	}
}
