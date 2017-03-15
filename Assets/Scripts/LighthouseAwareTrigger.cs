using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseAwareTrigger : MonoBehaviour {
	AudioSource audioSource;

	public Lighthouse lighthouse;

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Player")
		{
			lighthouse.trackPlayer = true;
			audioSource.Play();
		}
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.tag == "Player")
		{
			lighthouse.trackPlayer = false;
			audioSource.Stop();
		}
	}
}
