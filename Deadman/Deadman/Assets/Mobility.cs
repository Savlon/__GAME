using UnityEngine;
using System.Collections;

public class Mobility
{
	private Entity _entity;
	private Transform _transform;
	private Vector3 _velocity;
	
	public Mobility (Entity entity)
	{
		_entity = entity;
	}
	
	public Entity MyEntity
	{
		get {return _entity;}
		set {_entity = value;}
	}
	
	public Transform MyTransform
	{
		get {return _transform;}
		set {_transform = value;}
	}
	
	public Vector3 Velocity
	{
		get {return _velocity;}
		set {_velocity = value;}
	}
	
	public Vector3 Position
	{
		get {return _transform.position;}
		set {_transform.position = value;}
	}
}