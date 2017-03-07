using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {
	Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void ReceiveKnockback (Vector3 direction, float force)
	{
		rb.AddForce(direction * force);
	}
}
