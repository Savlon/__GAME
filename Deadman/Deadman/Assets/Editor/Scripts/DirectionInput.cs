using UnityEngine;
using System.Collections;

public class DirectionInput
{
	public DirectionInput ()
	{}

	public void Update (Vector3 input, Vector3 reference, IFlipable entity)
	{
		entity.Flip ((input.x > reference.x));
	}
}
