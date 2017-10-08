using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLightScript : Activatable {

	public bool StartOnAwake = false;
	void Start()
	{
		if (StartOnAwake) {
			TurnOn ();
		} else
			TurnOff ();
	}
	public override void toggleActivation()
	{
		
		base.toggleActivation();

		if (isActive)
			TurnOn();
		else
			TurnOff();
	}

	public void TurnOn()
	{
		print ("light Should Activate");
		gameObject.SetActive (true);
	}

	public void TurnOff()
	{
		print ("light Should DeActivate");
		gameObject.SetActive (false);
	}
}
