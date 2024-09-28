using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Glower : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
	bool glowTrigger = false;
	Material material;
	Renderer renderer;

    public void OnPointerClick(PointerEventData eventData)
    {
		//if (glowTrigger)
  //      {
  //          material.DisableKeyword("_EMISSION");
  //      }
  //      else
  //      {
  //          material.EnableKeyword("_EMISSION");
  //      }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
            material.EnableKeyword("_EMISSION");
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        material.DisableKeyword("_EMISSION");
    }

    // Use this for initialization
    void Start () {
		renderer = GetComponent<Renderer>();
		material = renderer.material;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
