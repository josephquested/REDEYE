﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	// SYSTEM //

	PlayerController playerController;

	void Start ()
	{
		playerController = GetComponent<PlayerController>();
	}

	void Update ()
	{
		UpdateMovement();
	}

	// MOVEMENT //

	void UpdateMovement ()
	{
		playerController.ReceiveMovement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}
}
