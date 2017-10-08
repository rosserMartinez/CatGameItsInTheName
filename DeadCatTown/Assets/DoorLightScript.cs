using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLightScript : Activatable {


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
		gameObject.SetActive (true);
	}

	public void TurnOff()
	{
		gameObject.SetActive (false);
	}
}
