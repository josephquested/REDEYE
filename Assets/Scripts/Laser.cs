using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	public GameObject tailPrefab;
	public float spawnDelay;
	public ParticleSystem explosionParticles;

	bool canSpawnTail = true;

	void Start ()
	{
		Destroy(gameObject, 10);
	}

	void Update ()
	{
		if (canSpawnTail)
		{
			StartCoroutine(TailRoutine());
		}
	}

	IEnumerator TailRoutine ()
	{
		canSpawnTail = false;
		Instantiate(tailPrefab, transform.position, transform.rotation);
	 	yield return new WaitForSeconds(spawnDelay);
		canSpawnTail = true;
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.GetComponent<Status>() != null)
		{
			collider.gameObject.GetComponent<Status>().Damage(1);
			StartCoroutine(ExplodeRoutine());
		}
	}

	IEnumerator ExplodeRoutine ()
	{
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		explosionParticles.Play();
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}
}
