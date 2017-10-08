using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public LockedDoor door;

    PlayerInventory player = null;
    public bool canInteract = false;

	// Update is called once per frame
	void Update ()
    {
        if (canInteract && Input.GetKey(KeyCode.E))
        {
            player.addKey(this);

            Destroy(gameObject);
        }
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
        player = null;

        canInteract = false;
    }
}
