using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class InteractableScript : MonoBehaviour {

	public bool IsInteractableByPhysicalCat = false;
    MeshRenderer meshRenderer;
    float defaultMetallic;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMetallic = meshRenderer.material.GetFloat("_Metallic");
    }

    void OnTriggerEnter(Collider col)
	{
		if (IsInteractableByPhysicalCat == true && col.gameObject.tag == "PhysicalCat" ||
            IsInteractableByPhysicalCat == false && col.gameObject.tag == "AstralCat" ) 
		{
			SendMessage ("EnteredObjectRange", col.gameObject);

            meshRenderer.material.SetFloat("_Metallic", 1);
        }
    }

	void OnTriggerExit(Collider col)
	{
		if (IsInteractableByPhysicalCat == true && col.gameObject.tag == "PhysicalCat" ||
            IsInteractableByPhysicalCat == false && col.gameObject.tag == "AstralCat") 
		{
			SendMessage ("ExitedObjectRange", col.gameObject);

            meshRenderer.material.SetFloat("_Metallic", defaultMetallic);
        }
    }
}
