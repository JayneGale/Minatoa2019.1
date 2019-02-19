using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClosePortal : MonoBehaviour
{

    public GameObject portalButton;
	public GameObject portal;
	Animator portalAnimator;

	void Start () 
	{
		ButtonClicker buttonClicker; 
		buttonClicker = portalButton.GetComponent<ButtonClicker>();
		buttonClicker.OnClicked += Button_OnClicked;
		portalAnimator = portal.GetComponent<Animator>();
	}

void Button_OnClicked (bool buttonState)
	{		
		Debug.Log ("ButtonState is " + buttonState);
		portalAnimator.SetBool("isOpening", buttonState);
	}
}