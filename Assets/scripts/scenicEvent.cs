using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenicEvent : MonoBehaviour {
	public int eventSteps=1;
	
	[SerializeField]
	practiceScript ps;
	int valForStep;
	bool isUnused = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void eventTrue() { if (ps.actualStep == valForStep && isUnused) { ps.addActualStep(eventSteps); } }
}
