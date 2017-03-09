using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Gun : NetworkBehaviour {
	AudioSource audioSource;
	Animator animator;
	ParticleSystem particles;
	Light lightSource;
	CameraShake cameraShake;
	Rigidbody rb;

	[SyncVar]
	bool heating;

	public GameObject gun;
	public GameObject laserPrefab;
	public Transform laserSpawn;
	public Transform particleSpawn;
	public GameObject particlePrefab;

	[SyncVar]
	public float heat;

	public float heatSpeed;
	public float laserSpeed;
	public float recoil;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		animator = gun.GetComponent<Animator>();
		audioSource = gun.GetComponent<AudioSource>();
		lightSource = gun.GetComponentsInChildren<Light>()[0];
		cameraShake = GetComponentsInChildren<CameraShake>()[0];
		CmdSpawnParticles();
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
			CmdFire(transform.forward);
		}
	}

	[Command]
	void CmdFire (Vector3 direction)
	{
		GameObject laser = (GameObject)Instantiate(laserPrefab, laserSpawn.position, laserSpawn.rotation);
		laser.GetComponent<Rigidbody>().velocity = direction * laserSpeed;
		laserSpawn.gameObject.GetComponent<AudioSource>().Play();
		NetworkServer.Spawn(laser);
		Recoil();
	}

	[Command]
	void CmdSpawnParticles ()
	{
		GameObject particleObj = (GameObject)Instantiate(particlePrefab, particleSpawn.position, particleSpawn.rotation);
		particleObj.transform.parent = particleSpawn;
		particles = particleObj.GetComponent<ParticleSystem>();
		NetworkServer.Spawn(particleObj);
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
		Vector3 force = -rb.gameObject.transform.forward;
		rb.AddForce(force * recoil);
	}
}
