using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour {

	public bool IsInteractableByPhysicalCat = false;

	void OnTriggerEnter(Collider col)
	{
		if (IsInteractableByPhysicalCat = true && col.gameObject.tag == "PhysicalCat") 
		{
			SendMessage ("EnteredObjectRange", col.gameObject);
		}

		if (IsInteractableByPhysicalCat = true && col.gameObject.tag == "AstralCat") 
		{
			SendMessage ("EnteredObjectRange", col.gameObject);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (IsInteractableByPhysicalCat = true && col.gameObject.tag == "PhysicalCat") 
		{
			SendMessage ("ExitedObjectRange", col.gameObject);
		}

		if (IsInteractableByPhysicalCat = true && col.gameObject.tag == "AstralCat") 
		{
			SendMessage ("ExitedObjectRange", col.gameObject);
		}
	}
}
