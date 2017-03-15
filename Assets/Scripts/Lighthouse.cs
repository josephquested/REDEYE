using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour {
	Transform target;
	AudioSource audioSource;
	bool bakingPlayer;

	public GameObject eye;
	public float strength;
	public float bake;
	public float bakeSpeed;
	public ParticleSystem bakeParticles;
	public Light spotLight;
	public LighthouseAttackTrigger attackTrigger;
	public bool trackPlayer;

	void Start ()
	{
		target = GameObject.FindWithTag("Player").transform;
		audioSource = GetComponent<AudioSource>();
	}

	void Update ()
	{
		UpdateTracking();
		UpdateFire();
		UpdateBake();
	}

	void UpdateFire ()
	{
		if (attackTrigger.heat >= 1)
		{
			StartFire();
		}
		else
		{
			StopFire();
		}
	}

	void UpdateTracking ()
	{
		if (trackPlayer)
		{
			FacePlayer();
		}
		else
		{
			Rotate();
		}
	}

	void UpdateBake ()
	{
		if (bakingPlayer)
		{
			bake += bakeSpeed;
		}
		else
		{
			bake -= bakeSpeed;
		}
		if (bake >= 1)
		{
			if (GameObject.FindWithTag("Player") != null)
			{
				GameObject.FindWithTag("Player").GetComponent<Status>().Die();
				attackTrigger.heat = 0;
				StopFire();
			}
		}
		if (bake < 0)
		{
			bake = 0;
		}
	}

	void StartFire ()
	{
		bakingPlayer = true;
		bakeParticles.Play();
		audioSource.Play();
		spotLight.intensity = 300f;
	}

	void StopFire ()
	{
		bakingPlayer = false;
		audioSource.Stop();
		bakeParticles.Stop();
		spotLight.intensity = 20f;
	}

	void FacePlayer ()
	{
		Quaternion targetRotation = Quaternion.LookRotation (target.position - eye.transform.position);
		float str = Mathf.Min (strength * Time.deltaTime, 1);
		eye.transform.rotation = Quaternion.Lerp (eye.transform.rotation, targetRotation, str);
	}

	void Rotate ()
	{
		Quaternion targetRotation = Quaternion.LookRotation(Vector3.right);
		float str = Mathf.Min (strength * Time.deltaTime, 1);
		eye.transform.rotation = Quaternion.Lerp(eye.transform.rotation, targetRotation, str);
	}
}
