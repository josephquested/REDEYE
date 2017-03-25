using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneflyAttackTrigger : MonoBehaviour {
	AudioSource audioSource;
	public float heatSpeed;
	public float heat = 0;
	public bool heating;
	public bool inTrigger;

	void Awake ()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update ()
	{
		Heating(inTrigger);
		UpdateHeat();
		UpdateAudio();
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

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Player")
		{
			inTrigger = true;
		}
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.tag == "Player")
		{
			inTrigger = false;
		}
	}

	void UpdateAudio ()
	{
		audioSource.volume = heat;
	}
}
