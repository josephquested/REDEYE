using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {
	Moves moves;
	Gun gun;

	void Start ()
	{
		moves = GetComponent<Moves>();
		gun = GetComponentsInChildren<Gun>()[0];
	}

	void Update ()
	{
		MovementInput();
		FireInput();
	}

	void MovementInput ()
	{
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		{
			moves.ReceiveInput(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		}
	}

	void FireInput ()
	{
		gun.ReceiveInput(Input.GetButton("Fire1"));
	}
}
