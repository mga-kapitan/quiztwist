﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {

	public void SceneLoad (string scene)
	{
		SceneManager.LoadScene (scene);
	}
}
