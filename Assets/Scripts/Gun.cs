using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public GameObject laserPrefab;
	public Transform laserSpawn;
	public float laserSpeed;
	public float heatSpeed;
	public float coolSpeed;

	public float heat;

	void Start ()
	{

	}

	void Update ()
	{
		Cool();
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
	}
}
