using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour {
	Transform target;

	public GameObject eye;
	public float strength;
	public bool trackPlayer;

	void Start ()
	{
		target = GameObject.FindWithTag("Player").transform;
	}

	void Update ()
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

	void FacePlayer ()
	{
		Quaternion targetRotation = Quaternion.LookRotation (target.position - eye.transform.position);
		float str = Mathf.Min (strength * Time.deltaTime, 1);
		eye.transform.rotation = Quaternion.Lerp (eye.transform.rotation, targetRotation, str);
	}

	void Rotate ()
	{
		Quaternion targetRotation = Quaternion.LookRotation(Vector3.right);
		float str = Mathf.Min (strength * Time.deltaTime, 1);
		eye.transform.rotation = Quaternion.Lerp(eye.transform.rotation, targetRotation, str);
	}
}
