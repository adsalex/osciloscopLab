using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.UIElements;
using UnityEngine.EventSystems;

public class Tipper : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
	
	static Text text;
	static GameObject go;
	static string defaultText = "Здесь отображаются подсказки к элементам установки";
    [SerializeField]
    string elementTip = "Это тест 1";

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.text = elementTip;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.text = defaultText;
    }

    // Use this for initialization


    void Start () 
	{
        go = GameObject.Find("tipText");
        text = go.GetComponent<Text>();
    }


    // Update is called once per frame
    void Update () {
		
	}

}
