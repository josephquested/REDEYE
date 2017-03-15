using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Health {
	public override void Damage (int damage)
	{
		Die();
	}

	void Die ()
	{
		GameObject.FindWithTag("Exit").GetComponent<Exit>().DestroyLock();
		DeathParticles();
		Destroy(gameObject);
	}

	void DeathParticles ()
	{
		Instantiate(deathSystem, transform.position + deathSystemOffset, transform.rotation);
	}
}
