using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour {
	Rigidbody rb;
	public float speed;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void ReceiveInput (float horizontal, float vertical)
	{
		Vector3 movement = new Vector3(horizontal, 0, vertical);
		Move(movement);
	}

	void Move (Vector3 movement)
	{
		rb.AddRelativeForce(movement * speed);
	}
}
