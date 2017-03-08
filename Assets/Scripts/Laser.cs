using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Laser : NetworkBehaviour {
	public GameObject tailPrefab;
	public float spawnDelay;
	public float knockback;
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
		if (collider.gameObject.GetComponent<Knockback>() != null)
		{
			Vector3 direction = GetComponent<Rigidbody>().velocity;
			collider.gameObject.GetComponent<Knockback>().ReceiveKnockback(direction, knockback);
		}

		if (collider.gameObject.GetComponent<Status>() != null)
		{
			collider.gameObject.GetComponent<Status>().Damage(1);
			StartCoroutine(ExplodeRoutine());
		}
	}

	IEnumerator ExplodeRoutine ()
	{
		GetComponent<Collider>().enabled = false;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		explosionParticles.Play();
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}
}
