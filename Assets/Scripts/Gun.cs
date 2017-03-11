using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	Animator animator;
	Light gunLight;
	ParticleSystem gunParticles;
	AudioSource gunFireAudio;

	public GameObject gun;
	public AudioSource gunRumbleAudio;
	public Shake shake;
	public GameObject laserPrefab;
	public Transform laserSpawn;
	public float laserSpeed;
	public float heatSpeed;
	public float coolSpeed;

	public float heat;

	void Start ()
	{
		animator = GetComponent<Animator>();
		gunLight = gun.GetComponentInChildren<Light>();
		gunParticles = gun.GetComponentInChildren<ParticleSystem>();
		gunFireAudio = gun.GetComponent<AudioSource>();
	}

	void Update ()
	{
		UpdateLight();
		UpdateShake();
		UpdateAudio();
		UpdateParticles();
	}

	void Cool ()
	{
		if (heat <= 0)
		{
			heat = 0;
		}
		else
		{
			heat -= coolSpeed;
		}
	}

	public void Heat (bool shouldHeat)
	{
		if (shouldHeat)
		{
			if (heat >= 1)
			{
				heat = 1;
			}
			else
			{
				heat += heatSpeed;
			}
		}
		else
		{
			Cool();
		}
	}

	public void AttemptFire ()
	{
		if (heat >= 0.95f)
		{
			Fire();
		}
	}

	void Fire ()
	{
		GameObject laser = (GameObject)Instantiate(laserPrefab, laserSpawn.position, laserSpawn.rotation);
		laser.GetComponent<Rigidbody>().AddForce(transform.forward * laserSpeed);
		animator.SetTrigger("gun-fire");
		gunFireAudio.Play();
	}

	void UpdateLight ()
	{
		gunLight.range = heat * 3;
	}

	void UpdateAudio ()
	{
		gunRumbleAudio.volume = heat;
		gunRumbleAudio.pitch = heat * 3;
	}

	void UpdateParticles ()
	{
		if (heat > 0.5f)
		{
			gunParticles.Play();
		}
		else
		{
			gunParticles.Stop();
		}
	}

	void UpdateShake ()
	{
		shake.ReceiveInput(heat);
	}
}
