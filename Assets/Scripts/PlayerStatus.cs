using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerStatus : Status {
	public AudioClip dieSound;
	public GameObject eyeLight;

	[SyncVar]
	public bool damaged;

	public override void Damage (int damage)
	{
		if (!isServer)
    {
	    return;
    }

		if (damage > 1 || damaged)
		{
			Die();
		}
		else
		{
			damaged = true;
		}
	}

	public void Die ()
	{
		if (!isServer)
    {
	    return;
    }

		AudioSource audioSource = GetComponent<AudioSource>();
		audioSource.clip = dieSound;
		audioSource.Play();
		damaged = false;
		RpcRespawn();
	}

	[ClientRpc]
	void RpcRespawn()
	{
    if (isLocalPlayer)
    {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
      transform.position = Vector3.zero;
			print("damaged:");
			print(damaged);
    }
	}
}
