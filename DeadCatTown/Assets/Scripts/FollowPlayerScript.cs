using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPlayerScript : MonoBehaviour {

	GameObject cat;
	GameObject spiritCat;

	// Use this for initialization
	void Start () {

		cat = GameObject.Find("CATWALK");
		spiritCat = GameObject.Find("ASTRALCATWALK");
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 midpoint = (spiritCat.transform.position + cat.transform.position) / 2;


		//lerp to position
		//transform.position = new Vector3(cat.transform.position.x, cat.transform.position.y, cat.transform.position.z);
		transform.position = new Vector3(midpoint.x, midpoint.y, midpoint.z);
	}
}
