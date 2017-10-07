using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour {

	public bool IsInteractableByPhysicalCat = false;

	void OnTriggerStay(Collider col)
	{
		if (IsInteractableByPhysicalCat = true && col.gameObject.tag == "PhysicalCat") 
		{
			SendMessage ("EnteredObjectRange");
		}

		if (IsInteractableByPhysicalCat = true && col.gameObject.tag == "AstralCat") 
		{
			SendMessage ("EnteredObjectRange");
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (IsInteractableByPhysicalCat = true && col.gameObject.tag == "PhysicalCat") 
		{
			SendMessage ("ExitedObjectRange");
		}

		if (IsInteractableByPhysicalCat = true && col.gameObject.tag == "AstralCat") 
		{
			SendMessage ("EnteredObjectRange");
		}
	}
}
