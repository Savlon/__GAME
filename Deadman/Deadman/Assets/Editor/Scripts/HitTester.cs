using UnityEngine;
using System.Collections;

public class HitTester : MonoBehaviour 
{
	public Entity testEntity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Space))
		{
			testEntity.ApplyHit (new Hit (null, 10, HitType.MELEE));
			testEntity.ApplyHit (new Hit (null, 10, HitType.RANGE));
			testEntity.ApplyHit (new Hit (null, 10, HitType.MAGIC));
		}
	}
}
