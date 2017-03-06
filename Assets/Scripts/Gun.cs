using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	AudioSource audioSource;
	Animator animator;
	ParticleSystem particles;
	Light lightSource;
	CameraShake cameraShake;
	Rigidbody parentRb;

	bool heating;

	public GameObject laserPrefab;
	public Transform laserSpawn;
	public float heat;
	public float heatSpeed;
	public float laserSpeed;
	public float recoil;

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
		lightSource = GetComponentsInChildren<Light>()[0];
		cameraShake = transform.parent.GetComponentsInChildren<CameraShake>()[0];
		particles = transform.parent.GetComponentsInChildren<ParticleSystem>()[0];
		parentRb = transform.parent.gameObject.GetComponent<Rigidbody>();
	}

	void Update ()
	{
		UpdateAudio();
		UpdateLight();
		UpdateCameraShake();
		UpdateParticles();
	}

	public void ReceiveInput (bool shouldHeat)
	{
		if (shouldHeat)
		{
			heating = true;

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
			heating = false;

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
		if (heat >= 0.99f)
		{
			animator.SetTrigger("fire");
			Fire();
		}
		else
		{
			print("failed!");
		}
	}

	void Fire ()
	{
		var laser = Instantiate(laserPrefab, laserSpawn.position, laserSpawn.rotation);
		laser.GetComponent<Rigidbody>().AddForce(transform.forward * laserSpeed);
		laserSpawn.gameObject.GetComponent<AudioSource>().Play();
		Recoil();
	}

	void UpdateCameraShake ()
	{
		cameraShake.ReceiveInput(heat);
	}

	void UpdateAudio ()
	{
		audioSource.volume = heat;
		audioSource.pitch = heat * 3;
	}

	void UpdateLight ()
	{
		lightSource.range = heat * 3;
	}

	void UpdateParticles ()
	{
		if (heat > 0.5 && heating)
		{
			particles.Play();
		}
		else
		{
			particles.Stop();
		}
	}

	void Recoil ()
	{
		Vector3 force = -parentRb.gameObject.transform.forward;
		parentRb.AddForce(force * recoil);
	}
}
