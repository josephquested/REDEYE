using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int health;

	public void Damage (int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Die();
		}
	}

	void Die ()
	{
		print("i died!");
		Destroy(gameObject);
	}
}
