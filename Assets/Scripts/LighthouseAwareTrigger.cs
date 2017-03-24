using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseAwareTrigger : MonoBehaviour {
	AudioSource audioSource;

	public Lighthouse lighthouse;

	void Awake ()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Player")
		{
			audioSource.Play();
		}
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.tag == "Player")
		{
			audioSource.Stop();
			lighthouse.trackPlayer = false;
		}
	}
}
