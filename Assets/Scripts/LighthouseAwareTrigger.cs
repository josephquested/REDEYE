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

	void OnTriggerExit (Collider collider)
	{
		if (collider.tag == "Player")
		{
			lighthouse.trackPlayer = false;
		}
	}
}
