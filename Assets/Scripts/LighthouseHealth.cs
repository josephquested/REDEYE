using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseHealth : Health {
	public override void Die ()
	{
		DeathParticles();
		Destroy(transform.parent.GetComponent<Lighthouse>());
		transform.parent.GetComponent<DeadLighthouse>().enabled = true;
		Destroy(this);
	}
}
