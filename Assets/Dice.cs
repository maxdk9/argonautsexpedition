using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
	private bool landed = false;
	private bool thrown = false;
	private Rigidbody rb;
	private Vector3 initPosition;
	public int DiceValue;
	public DiceSide []  Sides;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		initPosition = transform.position;
		rb.useGravity = false;
		
		

	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			RollDice();
		}

		if (rb.IsSleeping() && thrown && !landed)
		{
			landed = true;
			rb.useGravity = false;
			SideValueCheck();
		}
		else if(rb.IsSleeping()&&landed&&this.DiceValue==0)
		{
			RollAgain();
		}
		
	}

	private void RollAgain()
	{
		Reset();
		RollDice();
	}

	private void RollDice()
	{

		if (thrown && landed)
		{
			Reset();
		}
		if (thrown||landed)
		{
			return;
		}

		thrown = true;
		rb.useGravity = true;
		rb.AddTorque(Random.Range(0,500),Random.Range(0,500),Random.Range(0,500));
	}

	private void Reset()
	{
		transform.position = initPosition;
		thrown = false;
		landed = false;
		rb.useGravity = false;

	}

	void SideValueCheck()
	{
		this.DiceValue = 0;
		foreach (DiceSide side in Sides)
		{
			if (side.OnGround)
			{
				this.DiceValue = side.Value;
				Debug.Log("Dice rolled result is "+this.DiceValue);
			}
		}
		
	}
}
