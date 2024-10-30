using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class TableScript : MonoBehaviour {

	[SerializeField]
	int deltaX =30;
	[SerializeField]
	int deltaY = 50;

	[SerializeField]
	float ElFieldCoeff = 0;


    [SerializeField]
    float inductionDivCoeff = 0;

	[SerializeField]
	float sensY = 0;
    [SerializeField]
    float sensX = 0;


	float induction;
    float elField;



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

	[SerializeField]
	float constArray;
    [SerializeField]
    int calcShift =4;
    string flNumRegex = @"-?\d+(\.\d+)?";
	[SerializeField]
	public StandScript sc;

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
			Debug.Log(texts[j]);
			
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
		string buff= input.text;
		Match match = Regex.Match(buff,flNumRegex);
		float val =0;

		if (float.TryParse(match.Value, out val))
		{

			if (CellToWrite < totalFieldLenght)
			{
				if (CellToWrite % columns > calcShift)
				{
					CellToWrite = ((CellToWrite / columns) + 1) * columns;
					tablefields[CellToWrite].text = match.Value;
				}
				else
				{
					tablefields[CellToWrite++].text = match.Value;
				}

			}
			else
			{
				CellToWrite = 0;
			}
		}
        input.text = "";
    }

	public void calculate() 
	{
		for (int i = 0; i < rows; i++)
		{
			bool signal = true;
			float[] parsingBufferArray = new float[4];
			
			for (int k = 0; k < parsingBufferArray.Length; k++)
			{
				if(!float.TryParse(tablefields[i * columns + k+1].text, out parsingBufferArray[k])) signal = false;
			
			}
			
			if (!signal) continue; 
			
            for (int j = 0; j < columns; j++)
            {
				switch (j) 
				{
					case 5:
						tablefields[i * columns + j].text = sensX.ToString();break;
                    case 6:
                        tablefields[i * columns + j].text = sensY.ToString(); break;
                    case 7:
                        tablefields[i * columns + j].text = (sensX * parsingBufferArray[2]).ToString();
                        break;//Hk
                    case 8:
						tablefields[i * columns + j].text = ((sc.Resistance* sc.Capacity  * sensY * parsingBufferArray[1])/inductionDivCoeff).ToString();
						break; //B ост
                    case 9:
                        
                        tablefields[i * columns + j].text = (ElFieldCoeff* sensX * parsingBufferArray[0]).ToString(); break;//H m
                    case 10:
                        tablefields[i * columns + j].text = ((sc.Resistance * sc.Capacity * ElFieldCoeff * sensY * parsingBufferArray[1]) / inductionDivCoeff).ToString();
                        break;//B m
                   


                }
                //tablefields[i * columns + j];
            }
        }
    }
}
