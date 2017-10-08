using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TurnOn()
	{
		gameObject.SetActive (true);
	}

	public void TurnOff()
	{
		gameObject.SetActive (false);
	}
}
