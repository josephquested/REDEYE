using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

	Canvas canvas;

	void Start ()
	{
		canvas = GetComponent<Canvas>();
	}

	void Update ()
	{
		if (canvas.worldCamera == null && GameObject.FindWithTag("MainCamera") != null)
		{
			canvas.worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		}
	}
}
