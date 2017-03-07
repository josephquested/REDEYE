using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCamera : MonoBehaviour {
	public NetworkStatus parentNetworkStatus;

	void Start () {
		if(!parentNetworkStatus.local)
		{
			GetComponent<Camera>().enabled = false;
			return;
		}
	}
}
