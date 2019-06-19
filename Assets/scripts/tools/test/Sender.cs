using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sender : MonoBehaviour {

	public static UnityEvent TestEvent=new UnityEvent();

	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((TestEvent != null) && Input.GetKeyDown(KeyCode.Space))
		{
			TestEvent.Invoke();
		}
		
	}
}
