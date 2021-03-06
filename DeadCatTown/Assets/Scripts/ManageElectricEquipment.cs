﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageElectricEquipment : AudioSystem {

	public List<GameObject> ElectricStuffInRoom = new List<GameObject>();
	public bool ElectricityIsOn = false;
	public bool CheckForInput = false;
	GameObject collidingCat = null;
	Vector3 freezeCatAt = new Vector3();
	/*
		Put 'Electric' component on electrical stuff which will turn on when electricity is on
	*/
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CheckForInput) 
		{
			if (collidingCat == null) {
				Debug.Log ("Error, checking for input on " + gameObject.name + " when there is no colliding cat set");
				return;
			}
			if (collidingCat.tag == "AstralCat") 
			{
				if (Input.GetKeyDown (KeyCode.F)) 
				{
					if (!ElectricityIsOn) 
					{
						collidingCat.GetComponent<SpiritScript> ().SpiritIsFrozen = true;
						ElectricityIsOn = true;
						TurnOnElectricStuff ();
						//lock astral cat pos here
					}
					else if (ElectricityIsOn) 
					{
						collidingCat.GetComponent<SpiritScript> ().SpiritIsFrozen = false;
						ElectricityIsOn = false;
						TurnOffElectricStuff ();
						//unlock astral cat pos
					}

				}
			}
				
		}
		//if (ElectricityIsOn) {
		//	TurnOnElectricStuff ();
		//	ElectricityIsOn = false;
		//}//test to see if it works
	}

	public void EnteredObjectRange(GameObject _currentCatCol)
	{
		
		//print ("Got the mesg");
		CheckForInput = true;
		collidingCat = _currentCatCol;
	}

	public void ExitedObjectRange()
	{
		CheckForInput = false;
		collidingCat = null;
	}

	public void TurnOnElectricStuff()
	{
		playLocalAudio (AudioType.BreakerSwitch, transform.position, GetComponent<AudioSource>().volume, false);
		foreach(GameObject appliance in ElectricStuffInRoom)
			{
			//activate appliance, turn on lights... etc
			appliance.GetComponent<Activatable>().toggleActivation();
			}
	}
	public void TurnOffElectricStuff()
	{
		foreach(GameObject appliance in ElectricStuffInRoom)
		{
			//tjurn off appliance, turn off lights... etc
			appliance.GetComponent<Activatable>().toggleActivation();
		}
	}
}
