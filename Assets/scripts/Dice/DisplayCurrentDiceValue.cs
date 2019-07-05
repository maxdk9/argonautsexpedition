using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCurrentDiceValue : MonoBehaviour
{

	public LayerMask dieValueColliderLayer;
	private Rigidbody rb;
	public bool rollComplete;
	public int Value = 0;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
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
			
		}
		
	}
	
	
	
	
}
