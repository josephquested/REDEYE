﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// SYSTEM //

	Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	// MOVEMENT //

	public float speed;

	public void ReceiveMovement (float horizontal, float vertical)
	{
		Vector3 movement = new Vector3(horizontal, 0, vertical);
		if (horizontal != 0 && vertical != 0) { movement = movement * 0.75f; }
		Move(movement);
	}

	void Move (Vector3 movement)
	{
		rb.AddRelativeForce(movement * speed);
	}
}
