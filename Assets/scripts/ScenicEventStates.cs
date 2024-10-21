using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenicEventStates : ScenicEventMin {
    [SerializeField]
    bool reqState;
    AnimSwitch sw;
    // Use this for initialization
    protected override void Start()
    {
        ps = GameObject.Find("table").GetComponent<practiceScript>();
        sw = GetComponent<AnimSwitch>();
    }
    // Update is called once per frame
    override protected void Update () 
	{
        if (ps.currentStep == forStep)
        {
            if (reqState == sw.stateReader)
            {
                ps.addActualStep(addSteps);
            }
        }
    }
}
