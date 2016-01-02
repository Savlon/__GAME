using UnityEngine;
using System.Collections;

public class Food : Item
{
	private int _healAmount;

	public Food (string name, string description, int healAmount) : base (name, description)
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
