using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PortalButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Transform pose;
	public float camDist;
	static GameObject flyCam;

    static GameObject frictingCam;
	public GameObject obj;
	// Use this for initialization
    void Start () {
		flyCam = GameObject.Find("flyCamera");
		frictingCam = flyCam.transform.Find("Camera").gameObject;
	}
	

	public void moveToPoint() 
	{
		flyCam.transform.position = pose.position;
		flyCam.transform.rotation = pose.rotation;
		Vector3 buff = frictingCam.transform.localPosition;
		buff.z = camDist;
		frictingCam.transform.localPosition = buff;
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
		Glower gl = obj.GetComponent<Glower>();
        Tipper tipper = obj.GetComponent<Tipper>();
		gl.OnPointerEnter(eventData);
		tipper.OnPointerEnter(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Glower gl = obj.GetComponent<Glower>();
        Tipper tipper = obj.GetComponent<Tipper>();
        gl.OnPointerExit(eventData);
        tipper.OnPointerExit(eventData);
    }
}
