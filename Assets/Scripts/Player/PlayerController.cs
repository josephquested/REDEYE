﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// SYSTEM //

	PlayerMovement playerMovement;

	void Start ()
	{
		playerMovement = GetComponent<PlayerMovement>();
	}

	// MOVEMENT //

	public void ReceiveMovement (float horizontal, float vertical)
	{
		if (horizontal != 0 || vertical != 0)
		{
			playerMovement.ReceiveMovement(horizontal, vertical);
		}
	}
}
