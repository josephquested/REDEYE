using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {
	public int locks;

	void Start ()
	{
		locks = GameObject.FindWithTag("RoomController").GetComponent<RoomController>().locks;
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Player")
		{
 			if (locks <= 0)
			{
				Win();
			}
		}
	}

	void DestroyLock ()
	{

	}

	void Win ()
	{
		print("win!");
	}
}
