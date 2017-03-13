using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCamera : MonoBehaviour {
	public float floatSpeed;

	void Update ()
	{
		transform.Translate(0, 0, -floatSpeed);
	}
}
