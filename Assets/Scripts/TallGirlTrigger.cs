using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallGirlTrigger : MonoBehaviour {
	TallGirl girl;

	void Start ()
	{
		girl = transform.parent.gameObject.GetComponent<TallGirl>();
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Player")
		{
			print("found the player");
			girl.Attack();
		}
	}
}
