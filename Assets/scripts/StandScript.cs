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
    public float voltage;
    [SerializeField]
    float capacity;
	
	[SerializeField]
	float ampModifyer = 2f;
    [SerializeField]
    float magnitudeModifyer = 1f;
    [SerializeField]
    float allWavesShiftX = 1f;
    
    [SerializeField]
    float secondWaveShiftX = 1f;
    [SerializeField]
    float secondWaveShiftY = 1f;
    [SerializeField]
    float maxVoltage = 220;
    [SerializeField]
    float resistance = 0;
    [SerializeField]
    float resistanceProportion = 1f;
    float baseResistance = 5500f;
    float voltagePercentage = 0.7f;
    [SerializeField]
	BankHandleScript[] CapasitorHandles;
	[SerializeField]
    BankHandleScript[] ResistorHandles;
    [SerializeField]
    VoltageScript transformator;
    float capacityProportion = 1f;
    float baseCapacity = 100f;
    
    public float Capacity { get { return capacity; } }

    public float Resistance { get { return resistance; } }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        resistance = ResistorHandles[0].HandleValue*1000+ ResistorHandles[1].HandleValue * 100+ ResistorHandles[2].HandleValue * 10;
        capacity= CapasitorHandles[0].HandleValue * 10 + CapasitorHandles[1].HandleValue  + CapasitorHandles[2].HandleValue * 0.1f;
        voltage = transformator.voltageProp;
        resistanceProportion = resistance / baseResistance;
        voltagePercentage = voltage/maxVoltage;
        capacityProportion = capacity / baseCapacity;
		plotGraph(line1, -resistanceProportion * 0.5f, capacityProportion);
        plotGraph(line2,resistanceProportion*0.5f,capacityProportion);
    }
	

    void plotGraph (LineRenderer line, float additionalShiftX = 0, float proportionMod = 1)
    {
        for (int i = 0; i < posCount; i++)
        {
            Vector3 buff = line.GetPosition(i);
            float x = (buff.x / maxAmplitude)*voltagePercentage  * ampModifyer + allWavesShiftX*voltagePercentage + additionalShiftX;

            x = Mathf.Clamp(x, -Mathf.PI / 2, Mathf.PI / 2);
            float f =( Mathf.Sin(x)) * voltagePercentage * maxAmplitude* proportionMod * magnitudeModifyer;

            buff.y = f;
            line.SetPosition(i, buff);
        }
    }

}
