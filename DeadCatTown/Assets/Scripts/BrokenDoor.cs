using UnityEngine;
using System.Collections;

public class BrokenDoor : Activatable
{
    bool opened = false;

    public void open()
    {//why does the door take so long to open
		//AudioSystem.playLocalAudio (AudioType.OpenDoor, transform.position, 1f);
        opened = true;
		GetComponent<NodeMover>().startMovement(false);
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public void close()
    {
        opened = false;
		GetComponent<NodeMover>().startMovement(true);
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
