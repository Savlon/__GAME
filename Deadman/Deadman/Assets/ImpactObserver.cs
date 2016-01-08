using UnityEngine;
using System.Collections;

public class ImpactObserver : MonoBehaviour 
{
	private Entity _entity;

	void Start () 
	{
	
	}

	public Entity IOEntity
	{
		get {return _entity;}
		set {_entity = value;}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (!_entity.IEImpact.CheckTrigger) return;

		if (_entity.IEImpact.IsTriggerEnter (other.tag))
			_entity.IEImpact.ContactObject = other.gameObject;
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (!_entity.IEImpact.CheckTrigger) return;

		if (_entity.IEImpact.IsTriggerStay (other.tag))
			_entity.IEImpact.ContactObject = other.gameObject;
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (!_entity.IEImpact.CheckTrigger) return;

		if (_entity.IEImpact.IsTriggerExit (other.tag))
			_entity.IEImpact.ContactObject = null;
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (!_entity.IEImpact.CheckCollision) return;

		if (_entity.IEImpact.IsCollisionEnter (other.gameObject.tag))
			_entity.IEImpact.ContactObject = other.gameObject;
	}

	void OnCollisionStay2D (Collision2D other)
	{
		if (!_entity.IEImpact.CheckCollision) return;

		if (_entity.IEImpact.IsCollisionStay (other.gameObject.tag))
			_entity.IEImpact.ContactObject = other.gameObject;
	}

	void OnCollisionExit2D (Collision2D other)
	{
		if (!_entity.IEImpact.CheckCollision) return;

		if (_entity.IEImpact.IsCollisionExit (other.gameObject.tag))
			_entity.IEImpact.ContactObject = null;
	}

}
