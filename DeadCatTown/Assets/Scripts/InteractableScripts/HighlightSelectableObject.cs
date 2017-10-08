using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSelectableObject : MonoBehaviour {

	private Vector4 blue;
	private Vector4 cyan;

	public float interactable;// = .06f;
	public float uninteractable = .0f;

	Renderer rend;
	// Use this for initialization
	void Start () {

		if (GetComponent<Renderer> ())
		{
			rend = GetComponent<Renderer> ();
			//rend.material.shader = Shader.Find("Outline");

	//		Debug.Log(rend.material.shader);
		} 


		blue = new Vector4(.2f, 1f, 1f, 1f);

		cyan = new Vector4(0f, .917f, 1f, 1f);
		//Debug.Log("blue = " + blue);
		//Debug.Log("cyan = " + cyan);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnteredObjectRange(GameObject col)
	{
		if (col.tag == "PhysicalCat") 
		{
			rend.material.SetVector("_OutlineColor", blue);
		}

		if (col.tag == "AstralCat") 
		{
			rend.material.SetVector("_OutlineColor", cyan);
		}

		//Debug.Log ("Change the color of " + gameObject.name);
		//rend.material.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));

		rend.material.SetFloat("_Outline", interactable);


		//Debug.Log("OUTLINE = " + rend.material.GetFloat("_Outline"));
		//Debug.Log("OUTLINE = " + rend.material.GetVector("_OutlineColor"));
	}

	public void ExitedObjectRange()
	{
		rend.material.SetFloat("_Outline", uninteractable);
	}
}
