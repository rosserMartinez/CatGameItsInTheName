using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTheBlock : MonoBehaviour {

	Rigidbody rb;
	bool checkInput = false;
	public float pushForce = 1500;
	GameObject collidingCat;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (checkInput) {
			if (Input.GetKeyDown (KeyCode.E)) {
				if (collidingCat.transform.position.z > transform.position.z) {
					rb.AddForce (Vector3.forward * -pushForce);
					rb.useGravity = true;
				} else {
					rb.AddForce (Vector3.forward * pushForce);
					rb.useGravity = true;
				}

				//Debug.Log("ADDING FORCE");
			}
		}
		rb.velocity = Vector3.Lerp (rb.velocity, Vector3.zero, 5f * Time.deltaTime);
	}

	public void EnteredObjectRange(GameObject collidingPlayer)
	{
		checkInput = true;
		collidingCat = collidingPlayer;
		//Debug.Log ("Change the color of " + gameObject.name);
		//.material.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		
	}

	public void ExitedObjectRange(GameObject collidingPlayer)
	{
		checkInput = false;
		collidingCat = null;
		rb.useGravity = false;

	}
}
