using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	Animator animator;
	Light gunLight;
	ParticleSystem gunParticles;

	public GameObject gun;
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
	}

	void Update ()
	{
		Cool();
		UpdateLight();
		UpdateShake();
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

	public void Heat ()
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
	}

	void UpdateLight ()
	{
		gunLight.range = heat * 3;
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
