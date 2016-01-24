using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour 
{
	private Transform _transform;
	private bool _remove;
	private float _speed;
	private float _normalSpeed;

	private int _health;
	private int _maxHealth;

	public Level _level;

	public int _oldXPosition;
	public int _oldYPosition;

	public int _knockbackX;
	public int _knockbackY;

	protected virtual void Awake ()
	{
		_transform = GetComponent <Transform> ();
	}

	public virtual void Initialize (Level level)
	{
		_speed = 1f;
		_normalSpeed = _speed;
		_remove = false;
		_level = level;
		_maxHealth = 1000;
		_health = _maxHealth;
	}

	public virtual void Finalize (Level level)
	{
		//Place something in here if you wish to do something prior to it being removed
		//I.e instantiate a blood spatter or body parts etc...
	}

	protected virtual void Start () 
	{

	}
	
	protected virtual void Update () 
	{
		if (_knockbackX != 0 || _knockbackY != 0)
		{
			Move (_knockbackX, _knockbackY);

			if (_knockbackX > 0)
				_knockbackX--;
			else if (_knockbackX < 0)
				_knockbackX++;

			if (_knockbackY > 0)
				_knockbackY--;
			else if (_knockbackY < 0)
				_knockbackY++;
			Debug.Log ("KnockBack = " + gameObject.name);
		}

		if (Health <= 0)
		{
			_remove = true;
		}
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

	public float NormalSpeed
	{
		get {return _normalSpeed;}
		set {_normalSpeed = value;}
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
