using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenicEventMin : MonoBehaviour {
	public int addSteps;
	public int forStep;
	[SerializeField]
	protected practiceScript ps;
	// Use this for initialization
	protected virtual void Start () {
		ps = GameObject.Find("table").GetComponent<practiceScript>();
	}

    // Update is called once per frame
    protected virtual void Update () {
		
	}
	private void moveStep() 
	{
		if(ps.actualStep == forStep) 
		{
				ps.addActualStep(addSteps);
		}
	}
}
