using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour 
{
	private Transform _transform;
	private bool _remove;
	private float _speed;

	private int _health;
	private int _maxHealth;

	public Level _level;

	protected virtual void Awake ()
	{
		_transform = GetComponent <Transform> ();
	}

	public virtual void Initialize (Level level)
	{
		_speed = 1f;
		_remove = false;
		_level = level;
		_maxHealth = 1;
		_health = _maxHealth;
	}

	protected virtual void Start () 
	{

	}
	
	protected virtual void Update () 
	{
	
	}

	public virtual void Move (float x, float y)
	{
		Vector3 direction = new Vector3 (x, y, 0);
		direction.Normalize ();

		Position += direction * _speed * Time.deltaTime;
		int xPos = Mathf.FloorToInt (Position.x);
		int yPos = Mathf.FloorToInt (Position.y);

		_level.GetTile (Position.x, Position.y).StepOn (_level, xPos, yPos, this);
	}

	public int Health
	{
		get {return _health;}
		set {_health = value;}
	}

	public int MaxHealth
	{
		get {return _maxHealth;}
		set {_maxHealth = value;}
	}

	public float Speed
	{
		get {return _speed;}
		set {_speed = value;}
	}

	public bool Remove
	{
		get {return _remove;}
		set {_remove = value;}
	}

	public Vector3 Position
	{
		get {return _transform.position;}
		set {_transform.position = value;}
	}
}
