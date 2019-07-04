using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RollDiceManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToDeckScene()
	{
		int i = 0;
		SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
	}
	
	
}
