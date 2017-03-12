using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TallGirl : MonoBehaviour {
	Rigidbody rb;
	Transform target;

  public float speed;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		target = GameObject.FindWithTag("Player").transform;
	}

  void Update ()
	{
		FacePlayer();
		MoveForward();
  }

	void FacePlayer ()
	{
		Vector3 targetDir = target.position - transform.position;
    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 10000, 0.0F);
    transform.rotation = Quaternion.LookRotation(newDir);
	}

	void MoveForward ()
	{
		rb.AddForce(transform.forward * speed);
	}
}
