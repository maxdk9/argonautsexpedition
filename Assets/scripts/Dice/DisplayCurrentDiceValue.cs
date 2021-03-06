﻿using System.Collections;
using System.Collections.Generic;
using Model.States;
using UnityEngine;

public class DisplayCurrentDiceValue : MonoBehaviour
{

	public LayerMask dieValueColliderLayer;
	private Rigidbody rb;
	
	public bool rollComplete;
	public bool diceRolled = false;
	public bool eventInvoked = false;
	
	
	
	
	
	public int Value = 0;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		diceRolled = false;
		eventInvoked = false;
	}

	// Update is called once per frame
	void Update ()
	{

		RaycastHit hit;
		Vector3 direction=new Vector3(0,0,-1);
		if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity, dieValueColliderLayer))
		{
				Value=hit.collider.GetComponent<DieValue>().Value;	
		}
		
		
		if (rb != null)
		{
			if (rb.IsSleeping()&&!rollComplete)
			{
			
				rollComplete = true;
				Debug.Log("Dice is rolled, value = "+Value);
			}

			if (diceRolled && rollComplete)
			{
				if (!eventInvoked)
				{
					BattleDiceRoll.ourInstance.diceRolledEvent.Invoke();
					eventInvoked = true;
				}
			}
		}
		
	}
	
	
	
	
}
