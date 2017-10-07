using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForInputIfInRange : MonoBehaviour {

	public bool InteractableWithPhysical = true;
	public bool InteractableWithAstral = false;
	bool CheckForInput = false;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () 
	{
		if (CheckForInput) 
		{
			if (InteractableWithPhysical) 
			{
				if (Input.GetKeyDown (KeyCode.E)) 
				{
					print ("Physical cat is interacting with " + gameObject.name);
				}
			}
			if (InteractableWithAstral) 
			{
				if (Input.GetKeyDown (KeyCode.F)) 
				{
					print ("Astral cat is interacting with " + gameObject.name);
				}
			}

		}
	}
	//TODO
	/*
		Make a case to check which interactable object is closer to the car.
		if there are 2 objects interactable it might break.
	*/
	public void EnteredObjectRange()
	{
		Debug.Log ("Check input on " + gameObject.name);
		CheckForInput = true;
	}

	public void ExitedObjectRange()
	{
		CheckForInput = false;
	}
}
