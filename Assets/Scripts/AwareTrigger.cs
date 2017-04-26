using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwareTrigger : MonoBehaviour {

	public bool aware;

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Player")
		{
			aware = true;
		}
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.tag == "Player")
		{
			aware = false;
		}
	}
}
