using UnityEngine;
using System.Collections;

public interface IMovable
{
	float Speed {get; set;}
	bool Frozen {get; set;}

	void Move (float x, float y);
}
