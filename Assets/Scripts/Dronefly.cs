using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dronefly : MonoBehaviour {
	Rigidbody rb;
	Transform target;
	Animator animator;

  public float speed;
  public float cooldown;
	public bool striking;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		target = GameObject.FindWithTag("Player").transform;
	}

  void Update ()
	{
		FacePlayer();
		Rise();

		if (!striking)
		{
			StartCoroutine(StrikeRoutine());
		}
  }

	IEnumerator StrikeRoutine ()
	{
		striking = true;
		yield return new WaitForSeconds(cooldown);
		striking = false;
		Strike();
	}

	void FacePlayer ()
	{
		Vector3 targetDir = target.position - transform.position;
    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 10000, 0.0F);
    transform.rotation = Quaternion.LookRotation(newDir);
	}

	void Strike ()
	{
		rb.velocity = transform.forward * speed;
	}

	void Rise ()
	{
		rb.AddForce(Vector3.up * 2);
	}
}
