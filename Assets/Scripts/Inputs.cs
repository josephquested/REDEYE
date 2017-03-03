using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {
	Moves moves;
	Gun gun;
	Blade blade;

	void Start ()
	{
		moves = GetComponent<Moves>();
		gun = GetComponentsInChildren<Gun>()[0];
		blade = GetComponentsInChildren<Blade>()[0];
	}

	void Update ()
	{
		MovementInput();
		FireInput();
		BladeInput();
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
		if (Input.GetButtonUp("Fire2"))
		{
			gun.AttemptFire();
		}
		gun.ReceiveInput(Input.GetButton("Fire2"));
	}

	void BladeInput ()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			blade.ReceiveInput();
		}
	}
}
