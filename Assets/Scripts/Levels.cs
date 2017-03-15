using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour {
	public Level[] levelsArray;

	void Awake ()
	{
		levelsArray = GetComponentsInChildren<Level>();
	}
}
