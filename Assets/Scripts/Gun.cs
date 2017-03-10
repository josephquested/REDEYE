using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	Animator animator;
	Light gunLight;

	public GameObject gun;
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
	}

	void Update ()
	{
		Cool();
		UpdateLight();
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
}
