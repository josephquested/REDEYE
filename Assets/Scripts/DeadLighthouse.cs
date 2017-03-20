using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLighthouse : MonoBehaviour {
	Transform target;

	public GameObject eye;
	public GameObject bakeParticles;
	public GameObject attackTrigger;
	public Renderer eyeRenderer;
	public GameObject heatParticles;
	public float strength;
	public Light ambientLight;
	public Light spotLight;

	void Start ()
	{
		target = GameObject.FindWithTag("Player").transform;
		GetComponent<AudioSource>();
		spotLight.color = Color.white;
		ambientLight.color = Color.white;
		eyeRenderer.material.color = Color.white;
		Destroy(attackTrigger);
		Destroy(bakeParticles);
		Destroy(heatParticles);
	}

	void Update ()
	{
		FacePlayer();
	}

	void FacePlayer ()
	{
		Quaternion targetRotation = Quaternion.LookRotation (target.position - eye.transform.position);
		float str = Mathf.Min (strength * Time.deltaTime, 1);
		eye.transform.rotation = Quaternion.Lerp (eye.transform.rotation, targetRotation, str);
	}
}
