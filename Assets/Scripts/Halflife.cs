using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halflife : MonoBehaviour {
	public float secondsAlive;

	void Start ()
	{
		Destroy(gameObject, secondsAlive);
	}
}
