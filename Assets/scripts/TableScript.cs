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
	InputField input;
	[SerializeField]
	int rows =4;
	int columns;
	int totalFieldLenght;

	[SerializeField]
	GameObject record;

	float proportionX;
	float proportionY;
	
	int CellToWrite=0;
    Text[] headers;
	[SerializeField]
	string[] texts;
    Text[] tablefields;
	 //List<Text> tablefields = new List<Text>();
	void Start () 
	{
		
		columns = texts.Length;
        totalFieldLenght = rows * columns;
        tablefields = new Text[totalFieldLenght];
        

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

        for (int i = 0; i < rows;i++) 
		{
			for(int j = 0;j< columns; j++) 
			{
				GameObject go = Instantiate(record,transform);
				go.transform.Translate(new Vector3(proportionX*j*deltaX, proportionY * (i+1) *-deltaY,0));
				tablefields[i * columns + j] = go.GetComponent<Text>();
			}
		}
		Debug.Log(totalFieldLenght);
		//tablefields[19].text = "2";
		Clear();
	}
	
	void Update () 
	{
			
	}

	public void Clear() 
	{
		foreach (Text t in tablefields) 
		{
			t.text = "/";
		}
		CellToWrite = 0;
	}
	public void WriteValue() 
	{
		if(CellToWrite < totalFieldLenght) 
		{
			tablefields[CellToWrite++].text = input.text;
			
		}
		else 
		{
			CellToWrite = 0;
		}
        input.text = "";
    }
}
