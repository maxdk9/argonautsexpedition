using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public float ForceAmount = 70.0f;
	public float TorqueAmount = 40.0f;

	public ForceMode ForceMode=ForceMode.VelocityChange;

	public string ButtonName = "Fire1";

	private Rigidbody rigidbody;
	private Vector3 startPosition=new Vector3(-0.8f,9.4f,-570);
	//private Vector3 startPosition;
	
	private Vector3[] diceDirections =
	{
		new Vector3(-2, -2, 1),
		new Vector3(-2, 2, 1),
		new Vector3(2, -2, 1),
	};

	
	


	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		Reset();
	}


	

	public void Reset()
	{
		this.transform.transform.localPosition = startPosition;
		//this.transform.rotation.Set(Random.Range(0,90),Random.Range(0,90),Random.Range(0,90),0);
		
		rigidbody.useGravity = false;
	}
	


	public void Roll()
	{
		
		
		rigidbody.useGravity = true;
		this.transform.rotation = Random.rotation;
		//int directionIndex = Random.Range(0, diceDirections.Length);
		int directionIndex = 0;
		Vector3 direction= diceDirections[directionIndex];
		for (int i = 0; i < 3; i++)
		{
			direction[i] = direction[i] * Random.Range(1, 3f);
		}
		
		Debug.Log(direction.ToString());
//		rigidbody.AddForce(Random.onUnitSphere*ForceAmount,ForceMode);
//		rigidbody.AddTorque(Random.onUnitSphere*TorqueAmount);
		
		rigidbody.AddForce(direction*ForceAmount,ForceMode);
		rigidbody.AddTorque(direction*TorqueAmount);
		DisplayCurrentDiceValue displayCurrentDiceValue = this.GetComponent<DisplayCurrentDiceValue>();
		displayCurrentDiceValue.rollComplete = false;
		displayCurrentDiceValue.diceRolled = true;
		displayCurrentDiceValue.eventInvoked = false;

	}

	
	
	
}
