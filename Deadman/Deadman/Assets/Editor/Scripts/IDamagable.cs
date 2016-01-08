using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IDamagable
{
	Hitpoints Health {get; set;}
	Queue<Hit> ReceivedHits {get; set;}

	void SendDeath (Entity source);
	void ApplyHit (Hit hit);
	void ProcessHit (Hit hit);
	void ProcessReceivedHits ();
	void HandleIngoingHit (Hit hit);
	bool IsDead ();
}
