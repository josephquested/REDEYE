using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {
	public Rigidbody rb;

	public void ReceiveKnockback (Vector3 direction, float force)
	{
		rb.AddForce(direction * force);
	}
}
