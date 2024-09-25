using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingCam : MonoBehaviour {

    [SerializeField]
    float MoveSpeed = 3f;

    [SerializeField]
    float RotationSpeedX = 45f;
    [SerializeField]
    float RotationSpeedY = 45f;

    [SerializeField]
    float xlow = -4f;
    [SerializeField]
    float xhigh = 4f;

    [SerializeField]
    float zlow = -4f;
    [SerializeField]
    float zhigh = 4f;


    [SerializeField]
    float scroll_coeff = 0.05f;
    [SerializeField]
    float scrollLimitLow = 0f;
    [SerializeField]
    float scrollLimitHigh = 3.5f;


    float rotationCam = 0f;
    Transform cam;

    Quaternion camRotation;

    // Use this for initialization
    void Start () {
        cam = transform.Find("Camera");

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2"))
        rotateCamera();

        moveCamera();
    }

    bool ControlDistance(float distance,float low,float high)
    {
        if (distance >= low && distance <= high) return true;
        return false;
    }

    float ControlDistancef(float distance, float low, float high)
    {
        if (distance <= low)
        {
            return low;
        }
        else if (distance >= high) 
        {
            return high;
        }
        else { return distance; }
        
        
    }


    void moveCamera()
    {
    
        
        Vector3 newpos = transform.position + new Vector3
            (
                 Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")
            )
            * Time.deltaTime * MoveSpeed; ;
        
        newpos.x = ControlDistancef(newpos.x, xlow, xhigh);
        newpos.z = ControlDistancef(newpos.z, zlow, zhigh);
        transform.position = newpos;
        float dscroll = Input.GetAxis("Mouse ScrollWheel")*Time.deltaTime*scroll_coeff;
        float scroll = ControlDistancef(cam.localPosition.z+dscroll, scrollLimitLow, scrollLimitHigh);
        cam.transform.localPosition = new Vector3(0, 0, scroll);


    }
    void rotateCamera()
    {
        transform.Rotate
            (
             Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * RotationSpeedX
            );
    }
}
