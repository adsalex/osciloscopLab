using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Hider : MonoBehaviour {
	// Use this for initialization
	bool enabled= false;
	Button btn;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void fold() 
	{ 
		gameObject.SetActive(enabled) ;
		enabled = !enabled;
	}
	

}
