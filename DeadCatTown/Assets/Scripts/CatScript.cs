﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour {

	PolygonCollider2D catbod;

	bool colliding;

	Rigidbody rb;

	public float moveSpeed;

	private Vector3 forward;
	private Vector3 right;

	private Vector3 upMove;
	private Vector3 rightMove;

	public LayerMask wallMask;
	public float checkDist;

	public Vector3 speed;
	public Vector3 force;
	public Vector3 rayPosition;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();

		forward = Camera.main.transform.forward;

		forward.y = 0;

		forward = Vector3.Normalize(forward);

		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

		speed = Vector3.zero;
		force = Vector3.zero;

	}


	public void addForce(Vector3 newForce)
	{
		force += newForce;
	}
	 

	// Update is called once per frame
	void Update () {

		rayPosition = transform.position;

		Vector3 moveDirection = Vector3.zero;

		if ( (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)) 
		{
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		upMove = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
		rightMove = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");

		Vector3 fixedAxis = Vector3.Normalize(rightMove + upMove);
		transform.forward = fixedAxis;

		rayPosition += rightMove;
		rayPosition += upMove;	

		if ((Physics.Raycast(rayPosition, fixedAxis, checkDist, wallMask)))
		{
				Debug.Log(" me");

				//if states here determingin which direction youre pointing vs the wall


				///     cehck rotation of objects in worldspace against eachother to determine angle youre at
				///----------------
				///    ^
				///    []
				///


				return;

		}
		else 
			{
				
				Debug.Log("nawwww");
				transform.position += rightMove;
				transform.position += upMove;				
		}
		}


	}
}
