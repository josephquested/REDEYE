using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour {
	public GameObject roomPrefab;
	public GameObject hallPrefab;

	public int roomCount;

	void Start ()
	{
		SpawnRoom();
	}

	void SpawnRoom ()
	{
		if (roomCount > 0)
		{
			GameObject room = (GameObject)Instantiate(roomPrefab, transform.position, transform.rotation);
			RoomController controller = room.GetComponent<RoomController>();
			int doorCount = Random.Range(1, 5);
			controller.CreateDoors(doorCount);
		}
		else
		{
			print("done spawning rooms");
		}
	}
}
