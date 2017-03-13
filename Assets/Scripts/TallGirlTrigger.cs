using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallGirlTrigger : MonoBehaviour {
	TallGirl girl;
	public float agroSpeed;

	public float agro = 0;

	void Start ()
	{
		girl = transform.parent.gameObject.GetComponent<TallGirl>();
	}

	void Update ()
	{
		if (agro > 0)
		{
			agro -= agroSpeed / 2;
		}
	}

	void OnTriggerStay (Collider collider)
	{
		if (collider.tag == "Player")
		{
			agro += agroSpeed;

			if (agro > 1)
			{
				agro = 0;
				girl.Attack();
			}
		}
	}
}
