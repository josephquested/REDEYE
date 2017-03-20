using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseAttackTrigger : MonoBehaviour {
	AudioSource audioSource;
	Transform target;

	public Lighthouse lighthouse;
	public Transform eyeCenter;
	public ParticleSystem heatParticles;
	public float heatSpeed;
	public float heat = 0;
	public bool heating;
	public bool inSpotlight;

	void Awake ()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update ()
	{
		PlayerCheck();
		UpdateHeat();
		UpdateParticles();
	}

	void UpdateHeat ()
	{
		if (heating)
		{
			heat += heatSpeed;
		}
		else
		{
			heat -= heatSpeed;
		}
		if (heat < 0)
		{
			heat = 0;
		}
		if (heat >= 1)
		{
			heat = 1;
		}
	}

	void PlayerCheck ()
	{
		if (lighthouse.trackPlayer && inSpotlight)
		{
			RaycastHit hit;
			if (Physics.Raycast(eyeCenter.position, eyeCenter.forward, out hit, Mathf.Infinity))
			{
				if (hit.collider.tag == "PlayerVisible")
				{
					Heating(true);
				}
				else
				{
					Heating(false);
				}
			}
		}
		else
		{
			Heating(false);
		}
	}

	void Heating (bool shouldHeat)
	{
		if (shouldHeat)
		{
			heating = true;
			audioSource.Play();
		}
		else
		{
			heating = false;
			audioSource.Stop();
		}
	}

	void UpdateParticles ()
	{
		if (inSpotlight)
		{
			heatParticles.Play();
		}
		else
		{
			heatParticles.Stop();
		}
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Player")
		{
			lighthouse.trackPlayer = true;
			inSpotlight = true;
		}
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.tag == "Player")
		{
			inSpotlight = false;
		}
	}
}
