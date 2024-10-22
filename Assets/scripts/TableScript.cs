using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableScript : MonoBehaviour {

	[SerializeField]
	int deltaX =120;
	[SerializeField]
	int deltaY = 50;

	[SerializeField]
	int rows =4;
	[SerializeField]
	int columns =5;

	[SerializeField]
	GameObject record;

	float proportionX;
	float proportionY;
	int valInd = 0;

    Text[] headers;
	[SerializeField]
	string[] texts;
    Text[] tablefields;
	 //List<Text> tablefields = new List<Text>();
	void Start () 
	{
		columns = texts.Length;
		tablefields = new Text[rows*columns];
       

		proportionY = Screen.height;
        proportionY /= 720;

        proportionX = Screen.width;
        proportionX /= 1280;

        for (int j = 0; j < columns; j++)
        {
            GameObject go = Instantiate(record, transform);
            go.transform.Translate(new Vector3(proportionX * j * deltaX, 0,0));
			Text text = go.GetComponent<Text>();
			text.text = texts[j];
        }

        for (int i = 1; i < rows;i++) 
		{
			for(int j = 0;j< columns; j++) 
			{
				GameObject go = Instantiate(record,transform);
				go.transform.Translate(new Vector3(proportionX*j*deltaX, proportionY * i *-deltaY,0));
			}
		}
	}
	
	void Update () 
	{
			
	}
}
