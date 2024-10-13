using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmpereScript : MonoBehaviour {
	public float voltage = 0;
	[SerializeField]
	float resistance =1000;
    float current = 0;
    [SerializeField]
	Text text;
	[SerializeField]
	Image image;
	[SerializeField]
	AnimSwitch diaposoneSwitch;
    [SerializeField]
    AnimSwitch powerSwitch;
    [SerializeField]
    VoltageScript vs;
    // Use this for initialization
    void Start () {
		//GameObject buffer= transform.Find("background").gameObject;
		//image = buffer.GetComponent<Image>();
		//text = buffer.transform.Find("Text").GetComponent<Text>();
        text.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        voltage = vs.voltageProp;
        current = voltage/resistance;
        if (powerSwitch.stateReader)
        {
			image.color = Color.white;
            if (diaposoneSwitch.stateReader)
            {
                text.text = (current).ToString();
            }
            else
            {
                text.text = "inf";
                
            }
        }
        else
        {
            image.color= Color.black;
        }

        
		
    }
}
