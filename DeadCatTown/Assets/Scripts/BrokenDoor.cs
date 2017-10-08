using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NodeMover))]
public class BrokenDoor : Activatable
{
    NodeMover currentMover;
    bool opened = false;


    private void Start()
    {
        currentMover = GetComponent<NodeMover>();
    }

    public void open()
    {//why does the door take so long to open
		//AudioSystem.playLocalAudio (AudioType.OpenDoor, transform.position, 1f);
        opened = true;
		GetComponent<NodeMover>().startMovement(false);
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public void close()
    {
        Debug.Log("called");
        opened = false;
		GetComponent<NodeMover>().returnToStart(true);
        GetComponent<BoxCollider>().isTrigger = false;
    }

    public override void toggleActivation()
    {
        base.toggleActivation();

        if (isActive)
            open();
        else
            close();
    }
}
