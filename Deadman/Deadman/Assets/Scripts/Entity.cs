using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity : MonoBehaviour, IDamagable
{
	protected Transform _transform;
	protected Hitpoints _health;
	protected Queue<Hit> _receivedHits;

	protected virtual void Awake () 
	{
		this._transform = GetComponent <Transform> ();
		this._receivedHits = new Queue<Hit> ();
	}

	public virtual void Initialize () 
	{
		this._health = new Hitpoints (1);
	}

	protected virtual void Start () 
	{
		Initialize ();
	}

	protected virtual void Update () 
	{
		if (_receivedHits.Count > 0)
			ProcessReceivedHits ();

		Debug.Log ("Health: " + Health.ToString ());
	}

	protected virtual void OnDestroy () {}
	
	public virtual void SendDeath (Entity source) 
	{
		Debug.Log ("Entity Destroyed");
		Destroy (gameObject);
	}
	
	public virtual void ApplyHit (Hit hit) 
	{
		if (IsDead ())
			return;

		_receivedHits.Enqueue (hit);
		HandleIngoingHit (hit);
	}
	
	public virtual void ProcessHit (Hit hit) 
	{
		if (IsDead () || hit.Type == HitType.NONE || hit.Type == HitType.MISSED)
			return;

		if (hit.Type == HitType.HEAL)
		{
			_health.Add (hit.Amount, hit.ExceedMax);
			return;
		}

		_health.Remove (hit.Amount);

		if (IsDead ())
		{
			SendDeath (hit.Source);
			return;
		}
	}
	
	public virtual void ProcessReceivedHits () 
	{
		Hit hit;
		int count = 0;

		while (_receivedHits.Count > 0 && ((hit = _receivedHits.Dequeue()) != null) && count++ < 10)
		{
			ProcessHit (hit);
		}
	}

	public virtual void HandleIngoingHit (Hit hit) 
	{
		Debug.Log ("ENTITY: " + hit.ToString ());
	}

	public virtual bool IsDead ()
	{
		return _health.Current <= 0;
	}

	//PROPERTIES
	public Hitpoints Health
	{
		get {return this._health;}
		set {this._health = value;}
	}

	public Queue<Hit> ReceivedHits 
	{
		get {return this._receivedHits;}
		set {this._receivedHits = value;}
	}

	public Vector3 Position
	{
		get {return this._transform.position;}
		set {this._transform.position = value;}
	}
}