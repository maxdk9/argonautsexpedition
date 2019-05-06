using System.Collections;
using System.Collections.Generic;
using screen;
using UnityEngine;

public class CommonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
		{
			GoToMainMenu();
		}
	}


	public void GoToMainMenu()
	{
		if (ScreenManager.instance.CurrentType() == ScreenManager.ScreenType.Mainmenu)
		{
			Application.Quit();
			return;
		}
		ScreenManager.instance.Show(ScreenManager.ScreenType.Mainmenu);
		
		
	}
}
