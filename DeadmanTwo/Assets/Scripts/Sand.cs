using UnityEngine;
using System.Linq;
using System.Collections;

public class Sand : Tile
{
	private Sprite[] images;
	private Sprite[] blueprints;

	private Sprite baseSprite;
	private Sprite overlaySprite;


	public Sand (int id, Vector3 position = new Vector3 (), bool passable = true) : base (id, position, passable)
	{
//		images = new Sprite[16];
//
//		blueprints = new Sprite[16];
//		blueprints = Resources.LoadAll <Sprite> ("Blueprint/");
//		blueprints = blueprints.OrderBy (s => int.Parse (s.name)).ToArray ();
//
//		baseSprite = Resources.Load <Sprite> ("Dirt");
//		overlaySprite = Resources.Load <Sprite> ("Sand");
//
//		images = SpriteMerger.CombineSpritesUsingBlueprintArray (blueprints, baseSprite, overlaySprite);
	}


}
