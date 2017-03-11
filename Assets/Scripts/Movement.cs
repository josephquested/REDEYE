using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	Rigidbody rb;

	public AudioSource ballAudio;
	public float speed;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		UpdateAudio();
	}

	public void ReceiveInput (float horizontal, float vertical)
	{
		Vector3 movement = new Vector3(horizontal, 0, vertical);
		if (horizontal != 0 && vertical != 0)
		{
			movement = movement * 0.75f;
		}
		Move(movement);
	}

	void Move (Vector3 movement)
	{
		rb.AddRelativeForce(movement * speed);
	}

	void UpdateAudio ()
	{
		ballAudio.volume = rb.velocity.magnitude / 12;
		ballAudio.pitch = rb.velocity.magnitude / 8;
	}
}
