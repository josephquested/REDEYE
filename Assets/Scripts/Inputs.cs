using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Inputs : NetworkBehaviour {
	Move move;
	Gun gun;
	Blade blade;

	void Start ()
	{
		move = GetComponent<Move>();
		gun = GetComponentsInChildren<Gun>()[0];
		blade = GetComponentsInChildren<Blade>()[0];
	}

	void Update ()
	{
		if (!isLocalPlayer)
		{
	    return;
		}
		MovementInput();
		FireInput();
		BladeInput();
	}

	void MovementInput ()
	{
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		{
			move.ReceiveInput(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
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
		if (Input.GetButtonUp("Fire1"))
		{
			blade.AttemptFire();
		}
		blade.ReceiveInput(Input.GetButton("Fire1"));
	}
}
