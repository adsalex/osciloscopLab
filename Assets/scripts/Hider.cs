using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Hider : MonoBehaviour {
	

	public void fold() 
	{
         //enabled = !enabled;

        gameObject.SetActive(!gameObject.activeSelf) ;
	}
	

}
