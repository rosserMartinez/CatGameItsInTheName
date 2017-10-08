using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForInputIfInRange : MonoBehaviour {

	public bool InteractableWithPhysical = true;
	public bool InteractableWithAstral = false;
	GameObject currentCatColliding = null;
	bool CheckForInput = false;
	// Use this for initialization

	
	// Update is called once per frame
	//BUG: Im p sure if astral cat collides with physical 
	void Update () 
	{
		if (CheckForInput) 
		{
			if (InteractableWithPhysical && currentCatColliding.tag == "PhysicalCat") 
			{
				if (Input.GetKeyDown (KeyCode.E)) 
				{
					//print ("Physical cat is interacting with " + gameObject.name);
				}
			}

			if (InteractableWithAstral && currentCatColliding.tag == "AstralCat") 
			{
				if (Input.GetKeyDown (KeyCode.F)) 
				{
					//print ("Astral cat is interacting with " + gameObject.name);
				}
			}

		}
	}
	//TODO
	/*
		Make a case to check which interactable object is closer to the car.
		if there are 2 objects interactable it might break.
	*/
	public void EnteredObjectRange(GameObject _currentCatCol)
	{
		Debug.Log ("Check input on " + gameObject.name);
		CheckForInput = true;
		currentCatColliding = _currentCatCol;
	}

	public void ExitedObjectRange()
	{
		CheckForInput = false;
		currentCatColliding = null;
	}
}
