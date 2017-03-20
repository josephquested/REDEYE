using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Health {
	public override void Die ()
	{
		GameObject.FindWithTag("Exit").GetComponent<Exit>().DestroyLock();
		DeathParticles();
		Destroy(gameObject);
	}
}
