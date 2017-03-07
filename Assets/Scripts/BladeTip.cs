using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTip : MonoBehaviour {
	public Blade blade;

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.GetComponent<Status>() != null)
		{
			if (blade.firing)
			{
				collider.gameObject.GetComponent<Status>().Damage(2);
			}
		}
	}
}
