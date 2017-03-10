using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public GameObject laserPrefab;
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
		print("attempt fire!");
	}
}
