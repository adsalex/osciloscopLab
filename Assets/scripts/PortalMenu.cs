using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PortalMenu : MonoBehaviour {
	[SerializeField]
	Transform[] points;
	[SerializeField]
	GameObject button;
	Button btn;
    [SerializeField]
    float[] camereDist;
    [SerializeField]
    string[] label;


    // Use this for initialization
    void Start () {
		for(int i = 0;i<points.Length && i<camereDist.Length && i<label.Length;i++)
		{
			GameObject buffer = Instantiate(button, this.transform);
			buffer.transform.Translate(0,-45*i,0);
			PortalButton pb = buffer.GetComponent<PortalButton>();
			pb.camDist= camereDist[i];
            pb.pose = points[i];
			GameObject labelObj = buffer.transform.Find("Text").gameObject;
			labelObj.GetComponent<Text>().text = label[i];
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
	void createBtn() 
	{
		Instantiate(button, this.transform);
    }
}
