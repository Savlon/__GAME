using UnityEngine;
using System.Collections;

public class Visual
{
	private Entity _entity;
	private SpriteRenderer _spriteRenderer;
	private Transform _transform;
	
	public Visual (Entity entity)
	{
		_entity = entity;
	}
	
	public Entity MyEntity
	{
		get {return _entity;}
		set {_entity = value;}
	}
	
	public SpriteRenderer MySpriteRenderer
	{
		get {return _spriteRenderer;}
		set {_spriteRenderer = value;}
	}
	
	public Transform MyTransform
	{
		get {return _transform;}
		set {_transform = value;}
	}
	
	public Vector3 Scale
	{
		get {return _transform.localScale;}
		set {_transform.localScale = value;}
	}
	
	public Quaternion Rotation
	{
		get {return _transform.rotation;}
		set {_transform.rotation = value;}
	}
}