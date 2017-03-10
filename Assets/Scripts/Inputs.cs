using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {
	Movement movement;

	void Start ()
	{
		movement = GetComponent<Movement>();
	}

	void FixedUpdate ()
	{
		MovementInput();
	}

	void MovementInput ()
	{
		movement.ReceiveInput(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}
}
