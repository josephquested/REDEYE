using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkUtility : NetworkBehaviour {
	public bool local;
	public GameObject laserPrefab;

	void Start ()
	{
		if (isLocalPlayer)
		{
			local = true;
		}
	}
	//
	// public void SpawnLaser (Transform laserSpawn, float laserSpeed)
	// {
	// 	if (local)
	// 	{
	// 		CmdSpawnLaser(laserSpawn.position, laserSpawn.rotation, laserSpeed);
	// 	}
	// }
	//
	// [Command]
	// void CmdSpawnLaser (Vector3 laserSpawnPosition, Quternion laserSpawnRotation, float laserSpeed)
	// {
	// 	GameObject laser = (GameObject)Instantiate(laserPrefab, laserSpawnPosition, laserSpawnRotation);
	// 	laser.GetComponent<Rigidbody>().velocity = laser.transform.forward * laserSpeed;
	// 	laserSpawn.gameObject.GetComponent<AudioSource>().Play();
	// 	NetworkServer.Spawn(laser);
	// }
}
