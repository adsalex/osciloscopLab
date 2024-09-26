using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimSwitch : MonoBehaviour,IPointerClickHandler {

	Animator animator;
	bool state;
	
	AudioSource audio;
	void Start () {
		animator = GetComponent<Animator>();
        state = animator.GetBool("on");
		audio = GetComponent<AudioSource>();	
    }
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.M)) 
		{
            changeState();
        }
    }
	public void OnPointerClick(PointerEventData eventData)
	{
		changeState();

    }

    void changeState() 
	{
        state = !state;
        animator.SetBool("on", state);
        if (audio != null)
            audio.Play();
    }
    }
