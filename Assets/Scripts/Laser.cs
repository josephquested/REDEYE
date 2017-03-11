using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	Light laserLight;

	public GameObject tailPrefab;
	public float cooldown;
	public float decay;

	void Start ()
	{
		StartCoroutine(TailRoutine());
		laserLight = GetComponentInChildren<Light>();
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
		yield return new WaitForSeconds(0.001f);
		StartCoroutine(FadeRoutine());
	}
}
