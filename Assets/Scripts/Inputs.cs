using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {
	Movement movement;
	Gun gun;

	void Start ()
	{
		movement = GetComponent<Movement>();
		gun = GetComponent<Gun>();
	}

	void Update ()
	{
		GunInput();
	}

	void FixedUpdate ()
	{
		MovementInput();
	}

	void MovementInput ()
	{
		movement.ReceiveInput(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}

	void GunInput ()
	{
		if (Input.GetButton("Fire2"))
		{
			gun.Heat();
		}
		if (Input.GetButtonUp("Fire2"))
		{
			gun.AttemptFire();
		}
	}
}
