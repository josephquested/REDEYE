using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {
	Animator animator;
	Rigidbody parentRb;
	// AudioSource audioSource;
	// ParticleSystem particles;
	CameraShake cameraShake;

	bool firing;

	public float thrust;
	public float cooldown;

	void Start ()
	{
		// audioSource = GetComponent<AudioSource>();
		// particles = transform.parent.GetComponentsInChildren<ParticleSystem>()[0];
		parentRb = transform.parent.gameObject.GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		cameraShake = transform.parent.GetComponentsInChildren<CameraShake>()[0];
	}

	void Update ()
	{
		UpdateAudio();
		UpdateCameraShake();
		UpdateParticles();
	}

	public void ReceiveInput ()
	{
		if (!firing)
		{
			StartCoroutine(FireRoutine());
		}
		else
		{
			print("already attacking");
		}
	}

	IEnumerator FireRoutine ()
	{
		print("firing");
		firing = true;
		animator.SetTrigger("fire");
		parentRb.AddForce(transform.parent.forward * thrust);
		yield return new WaitForSeconds(cooldown);
		firing = false;
	}

	void UpdateCameraShake ()
	{
		// cameraShake.ReceiveInput(heat);
	}

	void UpdateAudio ()
	{
		// audioSource.volume = heat;
		// audioSource.pitch = heat * 3;
	}

	void UpdateParticles ()
	{
		// if (heat > 0.5 && heating)
		// {
		// 	particles.Play();
		// }
		// else
		// {
		// 	particles.Stop();
		// }
	}
}
