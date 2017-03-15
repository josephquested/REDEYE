using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour {
	Transform target;

	public GameObject eye;

	void Start ()
	{
		target = GameObject.FindWithTag("Player").transform;
	}

	void Update ()
	{
		FacePlayer();
	}

	void FacePlayer ()
	{

		Vector3 targetDir = target.position - transform.position;
    Vector3 newDir = Vector3.RotateTowards(target.position, targetDir, 1, 0.0F);
    eye.transform.rotation = Quaternion.LookRotation(newDir);
	}
}
