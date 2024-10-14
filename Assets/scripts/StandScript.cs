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
    const float maxAmplitude = 0.15f;
	[SerializeField]
	const float coilProportion =0.1f;
    float current1;
	float voltage1;
	float capacity;

	[SerializeField]
	BankHandleScript[] CapasitorHandles;
	[SerializeField]
    BankHandleScript[] ResistorHandles;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0;i<posCount ;i++)
		{
			Vector3 buff = line1.GetPosition(i);
			float f = Mathf.Sin(buff.x/maxAmplitude/2)*maxAmplitude;
			buff.y = f;
            //buff.y = -maxAmplitude + maxAmplitude / 10 * i;
			line1.SetPosition(i, buff);
		}
	}
}
