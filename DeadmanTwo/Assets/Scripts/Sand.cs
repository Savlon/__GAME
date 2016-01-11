using UnityEngine;
using System.Linq;
using System.Collections;

public class Sand : Tile
{
	private Sprite[] images;
	private Sprite[] blueprints;

	private Sprite baseSprite;
	private Sprite overlaySprite;


	public Sand (int id, bool passable = true, bool isBaseTile = true) : base (id, passable, isBaseTile)
	{

	}


}
