using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NodeMover : MonoBehaviour
{
    public bool stopOnCompletion;
    public bool startImmidiately;
    public float lerpSpeed;
    float lerpTime;
    public bool inMotion = false;
    bool reversing = false;
    List<Transform> nodes = null;
    List<Vector3> nodePositions = null;
    int currentNode;
    Vector3 startPosition;
    Vector3 nextPosition;
    //    float currentLerpDist;
    float lerpStartTime;


    // Use this for initialization
    void Start()
    {
        nodes = new List<Transform>(transform.Find("Nodes").GetComponentsInChildren<Transform>());

        nodes.Insert(0, transform);

        initNodePositions();

        if (startImmidiately)
            startMovement();
    }

    void initNodePositions()
    {
        Transform nodeParent = transform.Find("Nodes");

        nodePositions = new List<Vector3>();

        foreach (Transform node in nodes)
        {
            if (node == nodeParent)
                continue;

            nodePositions.Add(node.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inMotion)
            move();
    }

    void move()
    {
        float currentLerpTime = Time.time - lerpStartTime;
        float percentComplete = currentLerpTime / lerpTime;

        //print (percentComplete);
        Vector3 lerpPos = Vector3.Lerp(startPosition, nextPosition, percentComplete);
        if (percentComplete >= 1f)
        {
            if (!(currentNode < 0) && !(currentNode >= nodePositions.Count))
            {
                startPosition = nodePositions[currentNode];
            }

            if (!reversing)
                currentNode++;
            else
                currentNode--;

            if (currentNode >= nodePositions.Count)
            {
                if (stopOnCompletion)
                {
                    stopMovement();

                    return;
                }

                startMovementFromNode(nodePositions.Count - 1, true);
            }
            else if (currentNode <= 0)
            {
                if (stopOnCompletion)
                {
                    stopMovement();

                    return;
                }

                reversing = false;

                startMovementFromNode(0);
            }
            //print ("start pos is " + startPosition);
            //print ("next pos is " + nextPosition);  
        }

        transform.position = lerpPos;
    }


    public void startMovement(bool _isReversed = false)
    {
        if (inMotion)
            return;

        if (nodePositions == null)
        {
            Debug.LogError("NodeMover " + gameObject.name + " has no nodes");
            return;
        }

        //AudioSystem.playLocalAudio (AudioType.OpenDoor, transform.position, .3f);
        int startNode;

        if (_isReversed)
        {
            startNode = nodePositions.Count - 1;
            currentNode = startNode - 1;
        }
        else
        {
            startNode = 0;
            currentNode = startNode + 1;
        }

        if (currentNode < 0 || currentNode == nodePositions.Count)
            return;

        lerpStartTime = Time.time;

        startPosition = nodePositions[startNode];

        nextPosition = nodePositions[currentNode];

        lerpTime = Vector3.Distance(startPosition, nextPosition) / lerpSpeed;

        reversing = _isReversed;

        inMotion = true;
    }

    public void startMovementFromNode(int _nodeIndex, bool _isReversed = false)
    {
        if (inMotion)
            return;

        if (nodePositions == null)
        {
            Debug.LogError("NodeMover " + gameObject.name + " has no nodes");
            return;
        }

        //AudioSystem.playLocalAudio (AudioType.OpenDoor, transform.position, .3f);
        int startNode = _nodeIndex;

        if (_isReversed)
        {
            currentNode = startNode - 1;
        }
        else
        {
            currentNode = startNode + 1;
        }

        if (currentNode < 0 || currentNode <= nodePositions.Count)
        {
            Debug.LogError("NodeMover " + gameObject.name + " attempted out of range movement");
            return;
        }

        lerpStartTime = Time.time;

        startPosition = nodePositions[startNode];

        nextPosition = nodePositions[currentNode];

        lerpTime = Vector3.Distance(startPosition, nextPosition) / lerpSpeed;

        reversing = _isReversed;

        inMotion = true;
    }

    public void returnToStart(bool _interruptMotion = false)
    {
        if (inMotion && !_interruptMotion)
            return;

        if (nodePositions == null)
        {
            Debug.LogError("NodeMover " + gameObject.name + " has no nodes");
            return;
        }

        lerpStartTime = Time.time;

        startPosition = transform.position;

        nextPosition = nodePositions[0];

        lerpTime = Vector3.Distance(startPosition, nextPosition) / lerpSpeed;

        reversing = true;

        inMotion = true;
    }

    public void stopMovement()
    {
        Debug.Log("stopped");
        inMotion = false;
    }
}
