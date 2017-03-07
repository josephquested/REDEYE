using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadStatus : Status {
	public override void Damage (int damage)
	{
		Die();
	}

	void Die ()
	{
		transform.parent.gameObject.GetComponent<PlayerStatus>().Die();
		Destroy(gameObject);
	}
}
