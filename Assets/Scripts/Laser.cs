using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	public GameObject tailPrefab;
	public float cooldown;

	void Start ()
	{
		StartCoroutine(TailRoutine());
	}

	IEnumerator TailRoutine ()
	{
		yield return new WaitForSeconds(cooldown);
		Instantiate(tailPrefab, transform.position, transform.rotation);
		StartCoroutine(TailRoutine());
	}
}
