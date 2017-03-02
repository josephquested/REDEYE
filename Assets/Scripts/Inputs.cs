using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {
	Moves moves;

	void Start ()
	{
		moves = GetComponent<Moves>();
	}

	void Update ()
	{
		MovementInput();
	}

	void MovementInput ()
	{
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		{
			moves.ReceiveInput(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		}
	}
}
