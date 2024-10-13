using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankHandleScript : MonoBehaviour {

	public int HandleValue { get; private set; }
	void Start () {
		HandleValue = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void HandleClick() 
	{
		transform.Rotate(Vector3.forward *36);
		HandleValue++;
		if (HandleValue >= 10) { HandleValue = 0; }
	}
}
