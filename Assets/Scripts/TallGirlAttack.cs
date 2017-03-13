using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallGirlAttack : MonoBehaviour {
	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Player")
		{
			collider.gameObject.GetComponent<Status>().Die();
		}
	}
}
