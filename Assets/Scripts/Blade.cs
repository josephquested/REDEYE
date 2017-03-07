﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {
	Animator animator;
	Rigidbody parentRb;
	AudioSource audioSource;
	ParticleSystem particles;
	CameraShake cameraShake;

	public float heat;
	public float heatSpeed;
	public float thrust;
	public float cooldown;
	public bool firing;

	void Start ()
	{
		particles = GetComponentsInChildren<ParticleSystem>()[0];
		audioSource = GetComponent<AudioSource>();
		parentRb = transform.parent.gameObject.GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		cameraShake = transform.parent.GetComponentsInChildren<CameraShake>()[0];
	}

	void Update ()
	{
		UpdateAnimator();
		UpdateParticles();
		// UpdateCameraShake();
	}

	public void ReceiveInput (bool shouldHeat)
	{
		if (shouldHeat)
		{
			animator.SetBool("heating", true);

			if (heat < 1)
			{
				heat += heatSpeed;
			}
			else
			{
				heat = 1;
			}
		}

		else
		{
			animator.SetBool("heating", false);

			if (heat > 0)
			{
				heat -= heatSpeed;
			}
			else
			{
				heat = 0;
			}
		}
	}

	public void AttemptFire ()
	{
		if (heat >= 0.99f && !firing)
		{
			animator.SetTrigger("fire");
			StartCoroutine(FireRoutine());
		}
	}

	IEnumerator FireRoutine ()
	{
		firing = true;
		audioSource.Play();
		parentRb.AddForce(transform.parent.forward * thrust);
		yield return new WaitForSeconds(cooldown);
		firing = false;
	}

	void UpdateParticles ()
	{
		if (heat > 0.99f && !firing)
		{
			particles.Play();
		}
		else
		{
			particles.Stop();
		}
	}

	public void UpdateAnimator ()
	{
		if (heat >= 0.99)
		{
			animator.SetBool("hot", true);
		}
		else
		{
			animator.SetBool("hot", false);
		}
	}
}
