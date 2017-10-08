using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour {

	GameObject cat;

	// Use this for initialization
	void Start () {

		cat = GameObject.Find("CATWALK");

	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position = new Vector3(cat.transform.position.x - 11, cat.transform.position.y + 10, cat.transform.position.z - 11);

	}
}
