using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivatable
{
    void toggleActivation();
}


public class AstralInteractable : MonoBehaviour
{
    public Activatable activatable;
    bool interactable = false;
	
	// Update is called once per frame
	void Update ()
    {
		if(interactable && Input.GetKeyDown(KeyCode.F))
        {
            activatable.toggleActivation();
        }
	}

    void EnteredObjectRange()
    {
        interactable = true;
    }

    void ExitedObjectRange()
    {
        interactable = false;
    }
}
