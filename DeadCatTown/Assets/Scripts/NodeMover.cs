using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NodeMover : MonoBehaviour
{
    public bool stopOnCompletion;
    public bool startImmidiately;
    public float lerpSpeed;
    bool reversing = false;
    bool inMotion = false;
    List<Transform> nodes = null;
    int currentNode;
    Vector3 startPosition;
    Vector3 nextPosition;
    float currentLerpDist;
    float lerpStartTime;


	// Use this for initialization
	void Start ()
    {
        nodes = new List<Transform>(transform.Find("Nodes").GetComponentsInChildren<Transform>());

        if (startImmidiately)
            startMovement();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (inMotion)
            move();
	}
    
    void move()
    {
		float currentLerpTime = Time.time - lerpStartTime;
        float percentComplete = currentLerpTime / lerpSpeed;

		//print (percentComplete);
        Vector3 lerpPos = Vector3.Lerp(startPosition, nextPosition, percentComplete);
		if (percentComplete >= 1f) {
			if (!reversing)
				currentNode++;
			else
				currentNode--;

			if (currentNode == nodes.Count) 
			{
				if (stopOnCompletion) {
					stopMovement ();

					return;
				}

				reversing = true;

				currentNode = nodes.Count - 2;
			} else if (currentNode < 0) {
				if (stopOnCompletion) {
					stopMovement ();

					return;
				}

				reversing = false;

				currentNode = 0;
			}

			lerpStartTime = Time.time;

			startPosition = transform.position;

			nextPosition = nodes [currentNode].position;
			//print ("start pos is " + startPosition);
			//print ("next pos is " + nextPosition);
		} 

			transform.position = lerpPos;
		

    }


    public void startMovement(bool _isReversed = false)
    {

        if (nodes == null)
        {
            Debug.LogError("NodeMover " + gameObject.name + " has no nodes");
            return;
        }

		AudioSystem.playLocalAudio (AudioType.OpenDoor, transform.position, .3f);
        if (_isReversed)
            currentNode = nodes.Count - 1;
        else
            currentNode = 0;

		lerpStartTime = Time.time;

        startPosition = transform.position;

        nextPosition = nodes[currentNode].position;

        inMotion = true;
		//print ("inMotion");
    }

    public void stopMovement()
    {
        Debug.Log("stopped");
        inMotion = false;
    }
}
