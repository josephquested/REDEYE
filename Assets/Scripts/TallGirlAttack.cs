using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallGirlAttack : MonoBehaviour {
	void OnTriggerEnter (Collider collider)
	{
		print(collider.tag);
		if (collider.tag == "Player")
		{
			Destroy(collider.gameObject);
		}
	}
}
