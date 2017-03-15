using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeCollider : MonoBehaviour {
	public Blade blade;
	
	void OnTriggerEnter (Collider collider)
	{
		blade.ReceiveCollider(collider);
	}
}
