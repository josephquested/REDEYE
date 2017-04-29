using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {
	public Level[] levels;
	public int levelNumber = 0;
	public Level currentLevel;

	void Awake ()
	{
		levels = GetComponentsInChildren<Level>();
		currentLevel = levels[levelNumber];
	}

	public void NextLevel ()
	{
		levelNumber++;
		currentLevel = levels[levelNumber];
	}
}
