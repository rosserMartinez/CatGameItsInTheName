using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NodeMover))]
public class LockedDoor : MonoBehaviour
{
    PlayerInventory player = null;
    bool canInteract = false;
    bool opened = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!opened && canInteract && Input.GetKeyDown(KeyCode.E))
        {
			//print ("Checking if can open");
            if (canOpen(player))
            {
				// ("opening");
                open();
            }
        }
	}

    public void open()
    {
		AudioSystem.playLocalAudio (AudioType.UnlockDoor, transform.position, 1f);
        opened = true;
        //GetComponent<BoxCollider>().isTrigger = true;
        GetComponent<NodeMover>().startMovement(false);
    }

    bool canOpen(PlayerInventory _player)
    {
        if (_player.keys.Contains(this))
            return true;

        return false;
    }

    void EnteredObjectRange(GameObject _player)
    {
        player = _player.GetComponent<PlayerInventory>();

        if (player == null)
            return;

        canInteract = true;
    }

    void ExitedObjectRange()
    {
        canInteract = false;

        player = null;
    }
}
