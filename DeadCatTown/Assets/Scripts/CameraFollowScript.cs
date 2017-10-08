using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

	private GameObject catToFollow;
	private Transform catCameraTarget;
	public float bigSmooth;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
			
		catToFollow = GameObject.Find("cameraRange");

	}

	// Update is called once per frame
	void Update () {

		if (catToFollow != null) 
		{
			Vector3 moveCamera = new Vector3(catToFollow.transform.position.x, catToFollow.transform.position.y, catToFollow.transform.position.z);
			transform.position = Vector3.Lerp(transform.position, moveCamera, bigSmooth * Time.deltaTime);
		}



		///////////////////////to track astral, lerp to midpoint instead of cat itself
	}
}
