using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenicEvent : MonoBehaviour {
	public int eventSteps=1;
	
	[SerializeField]
	practiceScript ps;
	bool isUnused = true;

	int internalStep =0;
	int maxInternStep = 1;
	public int[] stepArray;
	public int[] newSteps;
    bool[] isUnuseds;
    bool[] isValueable;
    public float[] actualVals;
    

    // Use this for initialization
    void Start () {
		for (int i = 0;i<stepArray.Length;i++) { isUnuseds[i] = true; }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void eventTrue() 
	{
		if (ps.actualStep == stepArray[internalStep] && isUnuseds[internalStep]) { ps.addActualStep(newSteps[internalStep]);internalStep++; } 
	}
}
