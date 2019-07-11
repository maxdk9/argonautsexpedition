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
	private Vector3 startPosition;
	
	
	
	
	
	private Vector3[] diceDirections =
	{
		new Vector3(-2, -2, 1),
		new Vector3(-2, 2, 1),
		new Vector3(2, -2, 1),
	};

	
	


	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		
	}


	public void SetStartPosition()
	{
		this.transform.transform.position = startPosition;
		
	}

	public void Reset()
	{
		SetStartPosition();
		rigidbody.useGravity = false;
	}
	
	// Use this for initialization
	void Start ()
	{
		startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
//		if (Input.GetKeyDown(KeyCode.Space))
//		{
//			Roll();
//		}
	}

	public void Roll()
	{
		
		
		rigidbody.useGravity = true;

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
