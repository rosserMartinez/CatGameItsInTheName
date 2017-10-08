using UnityEngine;
using System.Collections;

public class BrokenDoor : Activatable
{
    bool opened = false;

    public void open()
    {
        opened = true;
		GetComponent<NodeMover>().startMovement();
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public void close()
    {
        opened = false;
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
