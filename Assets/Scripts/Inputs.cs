﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {
	Movement movement;
	Gun gun;
	Blade blade;

	void Start ()
	{
		movement = GetComponent<Movement>();
		gun = GetComponent<Gun>();
		blade = GetComponent<Blade>();
	}

	void Update ()
	{
		GunInput();
		BladeInput();
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

	void BladeInput ()
	{
		blade.Heat(Input.GetButton("Fire1"));

		if (Input.GetButtonUp("Fire1"))
		{
			blade.AttemptFire();
		}
	}
}
