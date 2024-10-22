using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenicEventAmpere : ScenicEventMin {
    [SerializeField]
    AmpereScript AS;
    public float targetValue;

    override protected void Start () {
        AS = GetComponent<AmpereScript>();
        ps = GameObject.Find("table").GetComponent<practiceScript>();
    }
	
	// Update is called once per frame
	override protected void Update () {
		if (ps.currentStep == forStep)
        {
            Debug.Log(AS.Current); 
            if ( targetValue == AS.Current)
            {
                ps.addActualStep(addSteps);
            }
        }
	}
}
