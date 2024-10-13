using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoltageScript : MonoBehaviour {

	float voltage = 0;
	[SerializeField]
	const float voltageStep = 20;
    [SerializeField]
    const float voltageLim = 240;
	[SerializeField]
	Text voltageText;

    public float voltageProp{ get { return voltage; } }

	
	void Start () {
		voltageText.text = "0 V"; 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.V)) 
			{
				VoltageSwitch();
			}
		
	}
	public void VoltageSwitch() 
	{
		sbyte vector =0;
		if (Input.GetButton("action") && voltage>=0) 
		{
			vector = -1;
            if (voltage <= 0) { vector = 0; }
        }
		else if (voltage<voltageLim) 
		{
			vector = 1;
        }
		
        voltage =voltage + vector* voltageStep;
        voltageText.text = voltage.ToString() + " V";
        transform.Rotate(Vector3.forward * vector* 1.5f*voltageStep);
		 
	}
}
