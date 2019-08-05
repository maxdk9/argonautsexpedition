using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleToDestroy : MonoBehaviour
{
	private ParticleSystem _particleSystem;
	private void Awake()
	{
		this._particleSystem = this.GetComponent<ParticleSystem>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!this._particleSystem.IsAlive())
		{
			//GameObject.DestroyImmediate(this.gameObject);
		}
	}
}
