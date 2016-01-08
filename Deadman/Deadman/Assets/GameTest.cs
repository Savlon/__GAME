using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameTest : MonoBehaviour 
{
	private List<Entity> _players = new List<Entity> ();
	private List<Entity> _enemies = new List<Entity> ();

	void Start () 
	{
		Entity player = new Entity ();

		GameObject playerScene = new GameObject ();
		playerScene.name = "Player";
		playerScene.AddComponent <ImpactObserver> ().IOEntity = player;

		player.IEMobility = new Mobility (player);
		player.IEMobility.MyTransform = playerScene.transform;
		player.IEMobility.Position = new Vector3 (-2, 0, 0);

		player.IEImpact = new Impact (player);
		player.IEImpact.CollisionShape = playerScene.AddComponent <BoxCollider2D> ();
		(player.IEImpact.CollisionShape as BoxCollider2D).size = Vector2.one;
		player.IEImpact.CheckTrigger = true;
		player.IEImpact.CollisionShape.isTrigger = true;
		player.IEImpact.AddContactTag ("Enemy");
		player.IEImpact.MyRigidbody2D = playerScene.AddComponent <Rigidbody2D> ();
		player.IEImpact.MyRigidbody2D.gravityScale = 0f;

		player.IEVisual = new Visual (player);

		player.IEVisual.MySpriteRenderer = playerScene.AddComponent <SpriteRenderer> ();
		player.IEVisual.MySpriteRenderer.sprite = Resources.Load <Sprite> ("Player");

		playerScene.tag = "Player";
		_players.Add (player);


		Entity enemy = new Entity ();
		
		GameObject enemyScene = new GameObject ();
		enemyScene.name = "Enemy";
		enemyScene.AddComponent <ImpactObserver> ().IOEntity = enemy;
		
		enemy.IEMobility = new Mobility (enemy);
		enemy.IEMobility.MyTransform = enemyScene.transform;
		
		enemy.IEImpact = new Impact (player);
		enemy.IEImpact.CollisionShape = enemyScene.AddComponent <BoxCollider2D> ();
		(enemy.IEImpact.CollisionShape as BoxCollider2D).size = Vector2.one;
		enemy.IEImpact.CheckCollision = true;
		enemy.IEImpact.AddContactTag ("Player");
		
		enemy.IEVisual = new Visual (enemy);
		enemy.IEVisual.MySpriteRenderer = enemyScene.AddComponent <SpriteRenderer> ();
		enemy.IEVisual.MySpriteRenderer.sprite = Resources.Load <Sprite> ("Enemy");
		
		enemyScene.tag = "Enemy";
		_enemies.Add (enemy);

	}
	
	void Update () 
	{
		for (int i = 0; i < _players.Count; i++) {
			for (int j = 0; j < _enemies.Count; j++) {
				Entity p = _players[i];
				Entity e = _enemies[j];

				Debug.Log ("ECount " + _enemies.Count);

				if (p.IEImpact.ContactObject != null)
				{
					Destroy (p.IEImpact.ContactObject);
				}
			}
		}
	}
}
