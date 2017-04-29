using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {

	public int currentLevel = 0;
	public Text levelText;

	void Start ()
	{
		DontDestroyOnLoad(this);
		print(currentLevel);
	}

	void OnLevelWasLoaded ()
	{
		print("was loaded");
		// levelText.text = currentLevel.ToString();
	}
}
