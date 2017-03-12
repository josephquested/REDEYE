using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFade : MonoBehaviour {
	Light fadeLight;

	public float fadeSpeed;

	void Start ()
	{
		fadeLight = GetComponent<Light>();
	}

	void Update ()
	{
		fadeLight.range -= fadeSpeed;
	}
}
