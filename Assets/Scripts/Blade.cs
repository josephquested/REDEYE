using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {
	Animator animator;
	Rigidbody parentRb;
	AudioSource audioSource;
	// ParticleSystem particles;
	CameraShake cameraShake;

	bool firing;

	public float thrust;
	public float thrustPause;
	public float cooldown;

	void Start ()
	{
		// particles = transform.parent.GetComponentsInChildren<ParticleSystem>()[0];
		audioSource = GetComponent<AudioSource>();
		parentRb = transform.parent.gameObject.GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		cameraShake = transform.parent.GetComponentsInChildren<CameraShake>()[0];
	}

	void Update ()
	{
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
		yield return new WaitForSeconds(thrustPause);
		audioSource.Play();
		parentRb.AddForce(transform.parent.forward * thrust);
		yield return new WaitForSeconds(cooldown);
		firing = false;
	}

	void UpdateCameraShake ()
	{
		// cameraShake.ReceiveInput(heat);
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
