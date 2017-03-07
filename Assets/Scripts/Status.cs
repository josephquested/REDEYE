using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
	public bool damaged;
	public bool dead;

	public void ReceiveDamage (int damage)
	{
		if (damage > 1 || damaged)
		{
			Die();
		}
		else
		{
			damaged = true;
		}
	}

	void Die ()
	{
		dead = true;
		Destroy(gameObject);
	}
}
