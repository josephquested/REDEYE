using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerStatus : Status {
	Rigidbody rb;

	public AudioClip dieSound;
	public GameObject eyeLight;

	[SyncVar]
	public bool damaged;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

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

	public override void Knockback (Vector3 direction, float force)
	{
		rb.AddForce(direction * force);
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
