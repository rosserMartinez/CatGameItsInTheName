﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour, IActivatable
{
    protected bool isActive = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void toggleActivation()
    {
        isActive = !isActive;
    }
}
