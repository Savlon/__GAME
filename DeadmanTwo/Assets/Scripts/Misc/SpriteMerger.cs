using UnityEngine;
using System.Collections;

public class SpriteMerger : MonoBehaviour 
{
	public static Sprite CombineSprites (Sprite baseSprite, Sprite overlaySprite)
	{
		Sprite combinedSprite = null;

		Texture2D aTex = baseSprite.texture;
		Texture2D bTex = overlaySprite.texture;
		Texture2D combinedTexture = new Texture2D (32, 32, TextureFormat.RGBA32, false);

		Color32[] aTexPixels = aTex.GetPixels32 ();
		Color32[] bTexPixels = bTex.GetPixels32 ();

		Color32[] combinedPixels = new Color32[aTexPixels.Length];

		for (int i = 0; i < combinedPixels.Length; i++)
		{
			float red = (bTexPixels[i].r);
			float green = (bTexPixels[i].g);
			float blue = (bTexPixels[i].b);
			float alpha = (bTexPixels[i].a);

			if (alpha < 255f)
			{
				red = aTexPixels[i].r;
				green = aTexPixels[i].g;
				blue = aTexPixels[i].b;
				alpha = aTexPixels[i].a;
			}
			combinedPixels[i] = new Color32 ((byte)red, (byte)green, (byte)blue, (byte)alpha);
		}
		combinedTexture.SetPixels32 (combinedPixels);
		combinedTexture.Apply ();

		combinedSprite = Sprite.Create (combinedTexture, new Rect (0, 0, 32, 32), Vector2.zero, 32f);

		return combinedSprite;
	}

	public static Sprite[] CombineSpriteArray (Sprite baseSprite, Sprite[] overlaySprites)
	{
		Sprite[] combinedSpriteArray = new Sprite[overlaySprites.Length];

		for (int i = 0; i < combinedSpriteArray.Length; i++) {
			Sprite combinedSprite = CombineSprites (baseSprite, overlaySprites[i]);
			combinedSprite.name = overlaySprites[i].name;
			combinedSpriteArray[i] = combinedSprite;
		}

		return combinedSpriteArray;
	}

	private static Sprite CombineSpriteUsingBlueprint (Sprite blueprint, Sprite baseSprite, Sprite overlaySprite)
	{
		Sprite combinedSprite = null;

		Texture2D blueprintTexture = blueprint.texture;
		Texture2D baseSpriteTexture = baseSprite.texture;
		Texture2D overlaySpriteTexture = overlaySprite.texture;
		Texture2D combinedSpriteTexture = new Texture2D (32, 32, TextureFormat.RGBA32, false);

		Color32[] blueprintTextureColors = blueprintTexture.GetPixels32 ();
		Color32[] baseSpriteTextureColors = baseSpriteTexture.GetPixels32 ();
		Color32[] overlaySpriteTextureColors = overlaySpriteTexture.GetPixels32 ();
		Color32[] combinedSpriteTextureColors = new Color32[blueprintTextureColors.Length];

		for (int i = 0; i < combinedSpriteTextureColors.Length; i++)
		{
			float red = overlaySpriteTextureColors[i].r;
			float green = overlaySpriteTextureColors[i].g;
			float blue = overlaySpriteTextureColors[i].b;

			if (blueprintTextureColors[i] == Color.white)
			{
				red = baseSpriteTextureColors[i].r;
				green = baseSpriteTextureColors[i].g;
				blue = baseSpriteTextureColors[i].b;
			}
			combinedSpriteTextureColors[i] = new Color32 ((byte)red, (byte)green, (byte)blue, 255);
		}
		combinedSpriteTexture.SetPixels32 (combinedSpriteTextureColors);
		combinedSpriteTexture.Apply ();
		combinedSpriteTexture.filterMode = FilterMode.Point;

		combinedSprite = Sprite.Create (combinedSpriteTexture, new Rect (0, 0, 32, 32), Vector2.zero, 32f);

		return combinedSprite;
	}

	public static Sprite[] CombineSpritesUsingBlueprintArray (Sprite[] blueprintArray, Sprite baseSprite, Sprite overlaySprite)
	{
		Sprite[] combinedSpritesArray = new Sprite[blueprintArray.Length];

		for (int i = 0; i < combinedSpritesArray.Length; i++) {
			Sprite combinedSprite = CombineSpriteUsingBlueprint (blueprintArray[i], baseSprite, overlaySprite);
			combinedSprite.name = blueprintArray[i].name;
			combinedSpritesArray[i] = combinedSprite;
		}

		return combinedSpritesArray;
	}












}
