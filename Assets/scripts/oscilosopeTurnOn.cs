using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscilosopeTurnOn : MonoBehaviour {
	[SerializeField]
	AnimSwitch sw;
	LineRenderer lineRenderer;
	// Use this for initialization
	void Start () {
		lineRenderer= GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
			lineRenderer.enabled = sw.stateReader;
	}
}
