using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicker : MonoBehaviour {

	public GameObject buttonToPress;
	public bool buttonIsOn;
	MeshRenderer meshRenderer;
	public Texture buttonOn;
	public Texture buttonOff;
	Animator buttonAnimator;

	public delegate void clickAction(bool buttonState);
	public event clickAction OnClicked;

	void Start () 
	{
		meshRenderer = GetComponent<MeshRenderer> ();
		meshRenderer.material.SetTexture ("_MainTex", buttonOff);
		buttonAnimator = buttonToPress.GetComponent<Animator>();
		buttonIsOn = false;
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Minus)) 
		{
			DeactivateButton ();
		}
	}

	public void ActivateButton()
	{
		buttonIsOn = true;	
		RefreshButton();
	}

	public void DeactivateButton()
	{
		buttonIsOn = false;
		RefreshButton();
	}

	public void ToggleButton()
	{
		buttonIsOn = !buttonIsOn;
		Debug.Log ("ButtonIsOn is " + buttonIsOn);
		RefreshButton();
	}

	public void RefreshButton()
	{
		buttonAnimator.SetTrigger ("ButtonPress");
		meshRenderer.material.SetTexture ("_MainTex", buttonIsOn ? buttonOn : buttonOff);
		if (OnClicked != null) 
		{
			OnClicked (buttonIsOn);
		} 
	}
}