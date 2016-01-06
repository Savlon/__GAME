using UnityEngine;
using System.Collections;

public class Food : Item
{
	private int _healAmount;

	public Food (int id, string name, string description, float delay, int healAmount) : base (id, name, description, delay)
	{
		this._healAmount = healAmount;
	}

	public override bool Use (Player player)
	{
		if (player.Health < player.MaxHealth)
		{
			player.Health += _healAmount;

			if (player.Health > player.MaxHealth)
			{
				player.Health = player.MaxHealth;
			}
			Debug.Log ("Healed: " + player.name + " with an " + Name + " [" + player.Health + "/" + player.MaxHealth + "]");
			return true;
		}
		return false;
	}
}
