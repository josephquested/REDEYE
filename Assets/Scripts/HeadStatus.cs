using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadStatus : Status {
	public PlayerStatus playerStatus;

	public override void Damage (int damage)
	{
		Die();
	}

	void Die ()
	{
		playerStatus.Die();
	}

	void ViolentDie ()
	{
		playerStatus.Die();
		Destroy(gameObject);
	}
}
