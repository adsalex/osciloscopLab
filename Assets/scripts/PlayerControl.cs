using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	Transform cam;

	[SerializeField]
	float playerMoveSpeed = 5f;
    [SerializeField]
    float playerRotationSpeed = 45f;

    [SerializeField]
    float cameraRotationSpeedX = 45f;
    [SerializeField]
    float cameraRotationSpeedY = 45f;


    [SerializeField]
    float cameraRotationLimitX = 45f;
    [SerializeField]
    float cameraRotationLimitY = 45f;
    float rotationCam =0f;
    Quaternion camRotation;

    void Start () {
		cam = transform.Find("Main Camera");
        camRotation = cam.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        movePlayer();
        moveCamera();
        //Debug.Log(transform.eulerAngles.x);
	}

    void movePlayer() 
    {
        transform.Translate(
            new Vector3
            (
             Input.GetAxis("Horizontal") , 0, Input.GetAxis("Vertical") 
            ) * Time.deltaTime*playerMoveSpeed
            );
        transform.Rotate
            (
            new Vector3
            (
             0, Input.GetAxis("Mouse X"), 0
            ) * Time.deltaTime * playerRotationSpeed
            );/**/
    }
    void moveCamera() 
    {
        //l
        rotationCam += -Input.GetAxis("Mouse Y") * cameraRotationLimitX * Time.deltaTime;
        rotationCam = Mathf.Clamp(rotationCam, -cameraRotationLimitX, cameraRotationLimitX);
        cam.localRotation = Quaternion.Euler(rotationCam, cam.localRotation.y, cam.localRotation.z);
    }
}
