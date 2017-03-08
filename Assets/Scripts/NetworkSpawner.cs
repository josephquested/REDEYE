using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkSpawner : NetworkBehaviour {
	public void SpawnLaser (GameObject laser)
	{
		CmdFire(laser);
	}

	[Command]
	void CmdFire (GameObject laser)
	{
		NetworkServer.Spawn(laser);
	}
}
