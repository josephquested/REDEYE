using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour {
	Transform target;
	AudioSource audioSource;
	Shake shake;
	bool bakingPlayer;
	bool destroyedPlayer;

	public GameObject eye;
	public float strength;
	public float bake;
	public float bakeSpeed;
	public float rotateSpeed;
	public ParticleSystem bakeParticles;
	public Light spotLight;
	public Light bakeLight;
	public LighthouseAttackTrigger attackTrigger;
	public bool trackPlayer;
	public AudioClip explodePlayerClip;

	void Start ()
	{
		target = GameObject.FindWithTag("Player").transform;
		shake = GameObject.FindWithTag("MainCamera").GetComponent<Shake>();
		audioSource = GetComponent<AudioSource>();
	}

	void Update ()
	{
		UpdateTracking();
		UpdateFire();
		UpdateBake();
		UpdateAudio();
		UpdateLight();
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
			shake.ReceiveInput(bake * 4);
		}
		else
		{
			bake -= bakeSpeed;
		}
		if (bake >= 1 && !destroyedPlayer)
		{
			if (GameObject.FindWithTag("Player") != null)
			{
				GameObject.FindWithTag("Player").GetComponent<Status>().Die();
				destroyedPlayer = true;
				audioSource.pitch = 1;
				audioSource.clip = explodePlayerClip;
				audioSource.loop = false;
				audioSource.Play();
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
		spotLight.intensity = 50f;
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
		eye.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
	}

	void UpdateAudio ()
	{
		audioSource.volume = bake * 4;
		if (!destroyedPlayer)
		{
			audioSource.Play();
			audioSource.pitch = bake * 20;
		}
	}

	void UpdateLight ()
	{
		bakeLight.intensity = bake * 10;
	}
}
