using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenicEventStand : ScenicEventMin {

	// Use this for initialization
	
    StandScript stand;
    [SerializeField]
    float capValue;
    [SerializeField]
    float resValue;
	override protected void Start () {
		stand = GetComponent<StandScript>();
        ps = GameObject.Find("table").GetComponent<practiceScript>();
        
    }

    // Update is called once per frame
    override protected void Update () 
	{
        if (ps.actualStep == forStep)
        {
            if (capValue == stand.Capacity && resValue == stand.Resistance)
            {
                ps.addActualStep(addSteps);
            }
        }
    }
}
