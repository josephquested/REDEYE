using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCamera : MonoBehaviour {
	public NetworkUtility networkUtility;

	void Start () {
		if(!networkUtility.local)
		{
			GetComponent<Camera>().enabled = false;
			GetComponent<AudioListener>().enabled = false;
			return;
		}
	}
}
