using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {
	bool locked = true;

	public GameObject unlockEffects;
	public int lockCount;
	public GameObject[] locks;

	void Start ()
	{
		if (GameObject.FindWithTag("RoomController") != null)
		{
			lockCount = GameObject.FindWithTag("RoomController").GetComponent<RoomController>().locks;
		}
		SetLocks();

		if (lockCount == 0)
		{
			Unlock();
		}
	}

	void SetLocks ()
	{
		int locksToDelete = 8 - lockCount;
		for (int i = 0; i < locks.Length; i++)
		{
			if (locksToDelete > 0)
			{
				locksToDelete--;
				Destroy(locks[i]);
			}
			else
			{
				return;
			}
    }
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Player")
		{
 			if (!locked)
			{
				Win();
			}
		}
	}

	public void DestroyLock ()
	{
		for (int i = 0; i < locks.Length; i++)
		{
			if (locks[i] != null)
			{
				Destroy(locks[i]);
				lockCount--;
				if (lockCount == 0)
				{
					Unlock();
				}
				return;
			}
    }
	}

	void Unlock ()
	{
		locked = false;
		unlockEffects.SetActive(true);
		GetComponentInChildren<Light>().color = Color.green;
	}

	void Win ()
	{
		print("win!");
	}
}
