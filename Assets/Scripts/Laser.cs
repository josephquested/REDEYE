using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	Light laserLight;
	AudioSource laserAudio;

	public GameObject tailPrefab;
	public int damage;
	public float cooldown;
	public float decay;

	void Start ()
	{
		StartCoroutine(TailRoutine());
		laserLight = GetComponentInChildren<Light>();
		laserAudio = GetComponentInChildren<AudioSource>();
		StartCoroutine(FadeRoutine());
	}

	IEnumerator TailRoutine ()
	{
		Instantiate(tailPrefab, transform.position, transform.rotation);
		yield return new WaitForSeconds(cooldown);
		StartCoroutine(TailRoutine());
	}

	IEnumerator FadeRoutine ()
	{
		laserLight.range -= decay;
		laserAudio.volume -= decay / 20;
		yield return new WaitForSeconds(0.001f);
		StartCoroutine(FadeRoutine());
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.GetComponent<Health>() != null)
		{
			collider.gameObject.GetComponent<Health>().Damage(damage);
		}
	}
}
