using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<LockedDoor> keys; // list of doors player can open

	// Use this for initialization
	void Start ()
    {
        keys = new List<LockedDoor>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addKey(DoorKey _key)
    {
        keys.Add(_key.door);
    }
}
