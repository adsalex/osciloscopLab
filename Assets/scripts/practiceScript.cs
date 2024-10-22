using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class practiceScript : MonoBehaviour {

	public int actualStep { private set; get; }
	int cuSt;
	public int currentStep { get { return cuSt; } 
		set { 
			cuSt = value;
            practiceText.text = Description[currentStep];
		} 
	}
	public string[] Description;
	[SerializeField]
	Text practiceText;

	void Start () {
		Debug.Log(actualStep);
		currentStep = 0;
		actualStep = 0;
	}

	public void StepPlus() 
	{
		if ( currentStep < (Description.Length ) && currentStep < actualStep) { currentStep++; Debug.Log("+"); }
	}
    public void StepMinus() { if (currentStep >= 1) { currentStep--; Debug.Log("-"); } }
	public void addActualStep(int actual) 
	{
		actualStep += actual;
		currentStep = actualStep;
		
	}
}
