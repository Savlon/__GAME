using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Impact
{
	private Entity _entity;
	private GameObject _contactObject;
	private Collider2D _collisionShape;
	private Rigidbody2D _rigidbody2D;
	private List<string> _contactTags;
	private bool _checkTrigger;
	private bool _checkCollision;
	
	public Impact (Entity entity)
	{
		_entity = entity;
		_contactTags = new List <string> ();
		_checkTrigger = false;
		_checkCollision = false;
	}
	
	public void AddContactTag (string objectTag)
	{
		if (!_contactTags.Contains (objectTag))
			_contactTags.Add (objectTag);
	}
	
	public void RemoveContactTag (string objectTag)
	{
		if (_contactTags.Contains (objectTag))
			_contactTags.Remove (objectTag);
	}
	
	public Entity MyEntity
	{
		get {return _entity;}
		set {_entity = value;}
	}

	public Rigidbody2D MyRigidbody2D
	{
		get {return _rigidbody2D;}
		set {_rigidbody2D = value;}
	}

	public GameObject ContactObject
	{
		get {return _contactObject;}
		set {_contactObject = value;}
	}

	public bool CheckTrigger
	{
		get {return _checkTrigger;}
		set {_checkTrigger = value;}
	}

	public bool CheckCollision
	{
		get {return _checkCollision;}
		set {_checkCollision = value;}
	}
	
	public Collider2D CollisionShape
	{
		get {return _collisionShape;}
		set {_collisionShape = value;}
	}
	
	public bool IsCollisionEnter (string objectTag)
	{
		if (_contactTags.Contains (objectTag))
			return true;
		return false;
	}
	
	public bool IsCollisionStay (string objectTag)
	{
		if (_contactTags.Contains (objectTag))
			return true;
		return false;
	}
	
	public bool IsCollisionExit (string objectTag)
	{
		if (_contactTags.Contains (objectTag))
			return true;
		return false;
	}
	
	public bool IsTriggerEnter (string objectTag)
	{
		if (_contactTags.Contains (objectTag))
			return true;
		return false;
	}
	
	public bool IsTriggerStay (string objectTag)
	{
		if (_contactTags.Contains (objectTag))
			return true;
		return false;
	}
	
	public bool IsTriggerExit (string objectTag)
	{
		if (_contactTags.Contains (objectTag))
			return true;
		return false;
	}
}