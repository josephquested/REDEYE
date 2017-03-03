using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	AudioSource audioSource;
	Light lightSource;
	CameraShake cameraShake;

	public float heat;
	public float heatSpeed;

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
		lightSource = GetComponentsInChildren<Light>()[0];
		cameraShake = transform.parent.GetComponentsInChildren<CameraShake>()[0];
	}

	void Update ()
	{
		UpdateAudio();
		UpdateLight();
		UpdateCameraShake();
	}

	public void ReceiveInput (bool heating)
	{
		if (heating)
		{
			if (heat < 1)
			{
				heat += heatSpeed;
			}
			else
			{
				heat = 1;
			}
		}

		else
		{
			if (heat > 0)
			{
				heat -= heatSpeed;
			}
			else
			{
				heat = 0;
			}
		}
		print(heat);
	}

	void UpdateCameraShake ()
	{
		cameraShake.ShakeCamera(heat, heat);
	}

	void UpdateAudio ()
	{
		audioSource.volume = heat;
	}

	void UpdateLight ()
	{
		lightSource.range = heat * 3;
	}
}
