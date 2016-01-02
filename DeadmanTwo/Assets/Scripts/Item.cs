using UnityEngine;
using System.Collections;

public class Item
{
	private string _name;
	private string _description;



	public virtual bool InteractOn (Tile tile, Level level, int x, int y, Player player)
	{
		return false;
	}

	public virtual bool Interact (Player player, Entity entity)
	{
		return false;
	}

	public virtual bool CanAttack ()
	{
		return false;
	}
}
