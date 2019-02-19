using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinOrrery : MonoBehaviour {

	public Vector3 rotationSpeed;
	public GameObject orreryButton;
	bool spinning = false;

	// Use this for initialization
	void Start () {
		ButtonClicker buttonClicker; 
		buttonClicker = orreryButton.GetComponent<ButtonClicker>();
		buttonClicker.OnClicked += Button_OnClicked;
	}

	void Button_OnClicked (bool buttonState)
	{
		spinning = buttonState;
	}

	// Update is called once per frame
	void Update () {
		if (spinning) {
			gameObject.transform.eulerAngles += rotationSpeed;
		}
	}
	}