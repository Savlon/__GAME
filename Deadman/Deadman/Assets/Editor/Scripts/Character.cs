using UnityEngine;
using System.Collections;

public class Character : Entity, IMovable, IFlipable
{
	private float _speed;
	private bool _isFrozen;
	private KeyInput _keyInput;
	private DirectionInput _directionInput;

	protected override void Awake ()
	{
		base.Awake ();
	}

	public override void Initialize ()
	{
		_health = new Hitpoints (100);
		_speed = 2f;
		_isFrozen = false;
		_keyInput = new KeyInput ("Horizontal", "Vertical");
		_directionInput = new DirectionInput ();
	}

	protected override void Start ()
	{
		base.Start ();
	}

	protected override void Update ()
	{
		base.Update ();

		_keyInput.Update (this);
		_directionInput.Update (Input.mousePosition, Camera.main.WorldToScreenPoint (Position), this);
	}

	#region IFlipable implementation

	public void Flip (bool faceRight)
	{
		Vector3 newScale = _transform.localScale;

		if ((_transform.localScale.x > 0 && !faceRight) ||
		    (_transform.localScale.x < 0 && faceRight))
		{
			newScale.x *= -1;
			_transform.localScale = newScale;
		}
	}

	#endregion
	
	#region IMovable implementation
	public float Speed
	{
		get {return _speed;}
		set {_speed = value;}
	}

	public void Move (float x, float y)
	{
		Vector3 direction = new Vector3 (x, y, 0);
		direction.Normalize ();

		Position += direction * _speed * Time.deltaTime;
	}

	public bool Frozen 
	{
		get { return _isFrozen; }
		set { _isFrozen = value; }
	}
	#endregion
}
