using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadStatus : Status {
	public PlayerStatus playerStatus;

	public override void Damage (int damage)
	{
		if (!playerStatus.dead)
		{
			NormalDie();
		}
	}

	void NormalDie ()
	{
		playerStatus.Die();
	}

	void ViolentDie ()
	{
		playerStatus.Die();
		Destroy(gameObject);
	}
}
