using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : Activatable
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isActive)
            GetComponent<MeshRenderer>().material.color = Color.red;
        else
            GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
