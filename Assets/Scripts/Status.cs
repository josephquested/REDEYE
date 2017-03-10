using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Status : NetworkBehaviour {
	public virtual void Damage (int damage)
	{
		// override
	}

	public virtual void Knockback (Vector3 direction, float force)
	{
		// override
	}
}
