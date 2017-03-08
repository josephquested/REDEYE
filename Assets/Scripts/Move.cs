using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Move : NetworkBehaviour {
	Rigidbody rb;
	public float speed;


	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void ReceiveInput (float horizontal, float vertical)
	{
		if (!isLocalPlayer)
		{
			return;
		}

		Vector3 movement = new Vector3(horizontal, 0, vertical);

		if (horizontal != 0 && vertical!= 0)
		{
			movement = movement * 0.75f;
		}

		Movement(movement);
	}

	void Movement (Vector3 movement)
	{
		rb.AddRelativeForce(movement * speed);
	}
}
