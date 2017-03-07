using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkStatus : NetworkBehaviour {
	public bool local;

	void Start ()
	{
		if (isLocalPlayer)
		{
			local = true;
		}
	}
}
