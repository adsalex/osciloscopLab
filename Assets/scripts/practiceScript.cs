using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class practiceScript : MonoBehaviour {

	public int actualStep =0;
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
		currentStep = 0;
	}

	public void StepPlus() { if (currentStep < Description.Length-2 && currentStep<actualStep) currentStep++; }
    public void StepMinus() { if (currentStep > 0) currentStep--;  }
	public void addActualStep(int actual) 
	{
		actualStep += actual;
		currentStep += 1;
		
	}
}
