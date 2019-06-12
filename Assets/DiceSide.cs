using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSide : MonoBehaviour
{
	public bool OnGround { get; private set; }

	public int Value;

	private void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "Ground")
		{
			OnGround = true;
		 }
	}

	private void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "Ground")
		{
			OnGround = false;
		}
	}
}
