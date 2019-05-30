using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual : MonoBehaviour
{

	public static Visual instance;
	
	
	public GameObject CardPoint;
	public GameObject CardPointOutside;
	public GameObject CardDeck;
	public GameObject CardDeckFrame;

	private void Awake()
	{
		instance = this;
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
