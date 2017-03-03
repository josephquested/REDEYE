using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	Rigidbody playerRb;
	AudioSource audioSource;

	void Start ()
	{
		 playerRb = GetComponentsInParent<Rigidbody>()[0];
		 audioSource = GetComponent<AudioSource>();
	}

	void Update ()
	{
		UpdateAudio();
	}

	void UpdateAudio ()
	{
		audioSource.volume = playerRb.velocity.magnitude / 2;
	}
}
