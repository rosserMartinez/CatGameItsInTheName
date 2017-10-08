using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSelectableObject : MonoBehaviour {

	Renderer rend;
	// Use this for initialization
	void Start () {
		if (GetComponent<Renderer> ())
			rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnteredObjectRange()
	{
		Debug.Log ("Change the color of " + gameObject.name);
		rend.material.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
	}

	public void ExitedObjectRange()
	{
	}
}
