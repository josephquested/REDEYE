using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : Status {
	public bool damaged;
	public bool dead;
	public AudioClip dieSound;
	public GameObject eyeLight;

	public override void Damage (int damage)
	{
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
		dead = true;

		Destroy(GetComponent<Inputs>());
		Destroy(GetComponent<Move>());
	 	GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

		AudioSource audioSource = GetComponent<AudioSource>();
		audioSource.clip = dieSound;
		audioSource.Play();

		Destroy(eyeLight);
		Destroy(this);
	}
}
