using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkUtility : NetworkBehaviour {
	public bool local;

	void Start ()
	{
		if (isLocalPlayer)
		{
			local = true;
		}
	}

	public void SpawnLaser (GameObject laser)
	{
		print(laser);
		CmdSpawnLaser(laser);
	}

	[Command]
	void CmdSpawnLaser (GameObject laser)
	{
		NetworkServer.Spawn(laser);
	}
}
