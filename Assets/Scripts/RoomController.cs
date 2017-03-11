using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour {
	public GameObject[] walls;

	public void CreateDoors (int doorCount)
	{
		for (doorCount; doorCount > 0; doorCount--)
		{
			GameObject wallToDelete = walls[Random.Range(0, 4)]
		}
	}
}
