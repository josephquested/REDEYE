using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathCamera : MonoBehaviour {
	public float floatSpeed;

	void Update ()
	{
		transform.Translate(0, 0, -floatSpeed);

		if (Input.GetKeyDown("r"))
		{
			Restart();
		}

		if (Input.GetKeyDown("q"))
		{
			Quit();
		}
	}

	public void Restart ()
	{
		{
			SceneManager.LoadScene("main");
		}
	}

	public void Quit ()
	{
		{
			Application.Quit();
		}
	}
}
