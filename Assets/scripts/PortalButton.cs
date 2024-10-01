using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalButton : MonoBehaviour {
	public Transform pose;
	public float camDist;
	static GameObject flyCam;

    static GameObject frictingCam;
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
}
