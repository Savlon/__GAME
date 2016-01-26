using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Space))
		{
			Vector2Int v2i = new Vector2Int (1, 1);
			Vector3Int v3i = new Vector3Int (2, 2, 2);
			Vector2 v2 = new Vector2 (3, 3);
			Vector3 v3 = new Vector3 (4, 4, 4);

			Vector3 test = (Vector3)v2i;

			Debug.Log (test.ToString ());
		}
	}
}
