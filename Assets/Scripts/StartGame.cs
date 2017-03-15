using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour {

	void Update ()
	{
		if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
		{
			SceneManager.LoadScene("main");
		}
	}
}
