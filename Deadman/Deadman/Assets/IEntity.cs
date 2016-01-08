using UnityEngine;
using System.Collections;

public interface IEntity
{
	//Methods
	void IEUpdate ();
	void IEFixedUpdate ();
	void IEDestroy ();

	//Properties
	Health IEHealth {get; set;}
	Impact IEImpact {get; set;}
	Mobility IEMobility {get; set;}
	Visual IEVisual {get; set;}
	Weapon IEWeapon {get; set;}

	//Events
}