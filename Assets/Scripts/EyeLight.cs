using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLight : MonoBehaviour {
	Light eyeLight;
	public bool lit = true;

	public PlayerStatus playerStatus;
	public float flashSpeed;

	void Start ()
	{
		eyeLight = GetComponent<Light>();
	}

	void Update ()
	{
		if (playerStatus.damaged)
		{
			if (lit && eyeLight.intensity > 0)
			{
				eyeLight.intensity -= flashSpeed;
			}
			if (!lit && eyeLight.intensity < 7.99f)
			{
				eyeLight.intensity += flashSpeed;
			}
			if (lit && eyeLight.intensity <= 0)
			{
				lit = false;
			}
			if (!lit && eyeLight.intensity >= 7.99f)
			{
				lit = true;
			}
		}

		else
		{
			lit = true;
			eyeLight.intensity = 8f;
		}
	}
}
