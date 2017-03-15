using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseAttackTrigger : MonoBehaviour {
	AudioSource audioSource;

	public Lighthouse lighthouse;
	public ParticleSystem heatParticles;
	public float heatSpeed;
	public float heat = 0;
	public bool heating;

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update ()
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

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Player")
		{
			heating = true;
			heatParticles.Play();
			audioSource.Play();
		}
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.tag == "Player")
		{
			heating = false;
			heatParticles.Stop();
			audioSource.Stop();
		}
	}
}
