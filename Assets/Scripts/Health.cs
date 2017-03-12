using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public int health;
	public GameObject deathSystem;
	public Vector3 deathSystemOffset;

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
		DeathParticles();
		Destroy(gameObject);
	}

	void DeathParticles ()
	{
		Instantiate(deathSystem, transform.position + deathSystemOffset, transform.rotation);
	}
}
