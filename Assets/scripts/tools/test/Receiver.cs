using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Receiver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Sender.TestEvent.AddListener(Recolor);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Recolor()
	{
		Image img = this.GetComponent<Image>();
		img.color =new Color(Random.value, Random.value, Random.value);
	}
}
