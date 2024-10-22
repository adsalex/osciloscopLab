using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenicEventVoltage : ScenicEventMin {
	VoltageScript vs;
    public float targetValue;
    // Use this for initialization
    override protected void Start () {
		vs = GetComponent<VoltageScript>();
        ps = GameObject.Find("table").GetComponent<practiceScript>();
    }

    // Update is called once per frame
    override protected void Update () {
        if (ps.actualStep == forStep)
        {
            if ( targetValue == vs.voltageProp)
            {
                ps.addActualStep(addSteps);
            }
        }
    }
}
