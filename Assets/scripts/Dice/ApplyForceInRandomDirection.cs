using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public float ForceAmount = 10.0f;
	public float TorqueAmount = 10.0f;

	public ForceMode ForceMode=ForceMode.VelocityChange;

	public string ButtonName = "Fire1";

	private Rigidbody rigidbody;


	public bool canRolled=false;
	


	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Roll();
		}
	}

	private void Roll()
	{
		
		rigidbody.useGravity = true;
		rigidbody.AddForce(Random.onUnitSphere*ForceAmount,ForceMode);
		rigidbody.AddTorque(Random.onUnitSphere*TorqueAmount);
		this.GetComponent<DisplayCurrentDiceValue>().rollComplete = false;
	}

	
	
	
}
