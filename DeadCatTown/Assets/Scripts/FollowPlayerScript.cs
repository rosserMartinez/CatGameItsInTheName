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

		Vector3 midpoint = (cat.transform.position - spiritCat.transform.position) / 2;


		//lerp to position
		transform.position = new Vector3(cat.transform.position.x - 11, cat.transform.position.y + 10, cat.transform.position.z + 11);
		//transform.position = new Vector3(midpoint.x - 11, midpoint.y + 10, midpoint.z + 11);
	}
}
