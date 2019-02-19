using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOn : MonoBehaviour {
	
	public GameObject buttonToPress;
	public GameObject objectButtonOperates;
	public bool buttonIsActivated;
	MeshRenderer meshRenderer;
	public Texture buttonOn;
	public Texture buttonOff;
	Animator animator;

	// Use this for initialization
	void Start () 
	{
		meshRenderer = GetComponent<MeshRenderer> ();
		meshRenderer.material.SetTexture ("_MainTex", buttonOff);
		animator = gameObject.GetComponent<Animator>();
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			//Send the message to the Animator to activate the trigger parameter named "ButtonPress"
			animator.SetTrigger("ButtonPress");
			ToggleButton ();
		}
		if (Input.GetKeyDown (KeyCode.Equals)) 
		{
			animator.SetTrigger ("ButtonPress");
			ActivateButton ();
		}	 
		if (Input.GetKeyDown (KeyCode.Minus)) 
		{
			animator.SetTrigger ("ButtonPress");
			DeactivateButton ();
		}
		objectButtonOperates.SetActive (buttonIsActivated);

	}

	public void ActivateButton()
	{
		meshRenderer.material.SetTexture ("_MainTex", buttonOn);
		buttonIsActivated = true;			
	}

	public void DeactivateButton()
	{
		meshRenderer.material.SetTexture ("_MainTex", buttonOff);
		buttonIsActivated = false;
		objectButtonOperates.SetActive (false);
	}

	public void ToggleButton()
	{
		if (meshRenderer.material.GetTexture ("_MainTex") == buttonOff) 
		{
			meshRenderer.material.SetTexture ("_MainTex", buttonOn);
			buttonIsActivated = true;

			return;
		} 
		else if (meshRenderer.material.GetTexture ("_MainTex") == buttonOn) 
		{
			meshRenderer.material.SetTexture ("_MainTex", buttonOff);
			buttonIsActivated = false;
			return;
		} 
	}
}