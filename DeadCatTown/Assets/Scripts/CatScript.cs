using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour {

	PolygonCollider2D catbod;

	Rigidbody rb;

	public float moveSpeed;

	private Vector3 forward;
	private Vector3 right;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();

		forward = Camera.main.transform.forward;

		forward.y = 0;

		forward = Vector3.Normalize(forward);

		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Vector3 upMove = Vector3.zero;
		//Vector3 rightMove = Vector3.zero;
		//Vector3 moveDirection = Vector3.zero;

		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		//moveDirection = Camera.main.transform.TransformDirection(moveDirection);

	    //transform.position += moveDirection * moveSpeed * Time.deltaTime;
	
		Vector3 upMove = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
		Vector3 rightMove = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");

		Vector3 fixedAxis = Vector3.Normalize(rightMove + upMove);
		//transform.forward = fixedAxis;

		transform.position += rightMove;
		transform.position += upMove;
	
	}
}
