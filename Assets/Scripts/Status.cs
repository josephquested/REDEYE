using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
	public GameObject playerCamera;
	public GameObject deathCamera;

	public void Die ()
	{
		playerCamera.SetActive(false);
		GameObject cam = (GameObject)Instantiate(deathCamera, transform.position, transform.rotation);
		cam.transform.rotation = Quaternion.Euler(90, 0, 0);
		gameObject.SetActive(false);
	}
}
