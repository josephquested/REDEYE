using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public Level[] levelsArray;
	public int levelNumber = 0;
	public Level currentLevel;

	void Awake ()
	{
		levelsArray = GetComponentsInChildren<Level>();
		currentLevel = levelsArray[levelNumber];
	}

	public void NextLevel ()
	{

	}
}
