using UnityEngine;
using System.Collections;

public class Entity : IEntity
{
	private Health _health;
	private Impact _impact;
	private Mobility _mobility;
	private Visual _visual;
	private Weapon _weapon;

	public virtual void IEUpdate ()
	{
		
	}
	
	public virtual void IEFixedUpdate ()
	{
		
	}
	
	public virtual void IEDestroy ()
	{
		
	}
	
	public Health IEHealth 
	{
		get {return _health;}
		set {_health = value;}
	}

	public Impact IEImpact 
	{
		get {return _impact;}
		set {_impact = value;}
	}

	public Mobility IEMobility 
	{
		get {return _mobility;}
		set {_mobility = value;}
	}

	public Visual IEVisual 
	{
		get {return _visual;}
		set {_visual = value;}
	}

	public Weapon IEWeapon 
	{
		get {return _weapon;}
		set {_weapon = value;}
	}
}