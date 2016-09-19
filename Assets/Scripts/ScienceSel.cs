using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ScienceSel : MonoBehaviour {

	public void _scienceSel (string scene)
	{
		SceneManager.LoadScene(scene);
	}
}
