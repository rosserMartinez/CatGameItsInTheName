using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

	public GameObject catToFollow;
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
			Vector3 moveCamera = new Vector3(catToFollow.transform.position.x - 10, catToFollow.transform.position.y + 10, catToFollow.transform.position.z + 9);
			transform.position = Vector3.Lerp(transform.position, moveCamera, bigSmooth * Time.deltaTime);
		}
		///to track astral, lerp to midpoint instead of catsdfgsdfgsgsitself
	}
}
