using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandScript : MonoBehaviour {
	[SerializeField]
	LineRenderer line1;
	[SerializeField]
	LineRenderer line2;
	const int posCount = 20;
    [SerializeField]
    const float maxAmplitude = 0.14f;
	[SerializeField]
	const float coilProportion =0.1f;
    float current1;
	float voltage1;
	float capacity;
	
	[SerializeField]
	float ampModifyer = 2f;
    [SerializeField]
    float magnitudeModifyer = 1f;
    [SerializeField]
    float waveShift1 = 1f;
    [SerializeField]
    float waveShift2 = 1f;


    [SerializeField]
	BankHandleScript[] CapasitorHandles;
	[SerializeField]
    BankHandleScript[] ResistorHandles;


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		plotGraph(line1);
        plotGraph(line2,waveShift2);
    }
	void plotGraphN(LineRenderer line,float additionalShift=0) 
	{
        for (int i = 0; i < posCount; i++)
        {
            Vector3 buff = line.GetPosition(i);
            float f = Mathf.Sin(buff.x / (maxAmplitude) * ampModifyer + waveShift1+additionalShift) * maxAmplitude*magnitudeModifyer;
            buff.y = f;
            line.SetPosition(i, buff);
        }
    }

    void plotGraph (LineRenderer line, float additionalShift = 0)
    {
        float maxVal = 0;  

        for (int i = 0; i < posCount; i++)
        {
            Vector3 buff = line.GetPosition(i);
            float x = buff.x / (maxAmplitude) * ampModifyer + waveShift1 + additionalShift;

            x = Mathf.Clamp(x, -Mathf.PI / 2, Mathf.PI / 2);
            float f = Mathf.Sin(x) * maxAmplitude * magnitudeModifyer;

            
            if (x >= 0 && x <= Mathf.PI / 2)
            {
                buff.y = f; 
                maxVal = f; 
            }
            else
            {
               
                buff.y = maxVal;             }

            line.SetPosition(i, buff);
        }
    }

}
