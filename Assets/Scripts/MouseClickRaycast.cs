using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MouseClickRaycast : MonoBehaviour {

	public GameObject player;
	public CharacterController playerController;
	public bool buttonIsOn;
    public bool drawerIsOpen;
	private MouseLook mouseLook;
	private FirstPersonController rfpc;
	private Ray ray;

//change cursor to a hand
	public bool cursorIsOver;
	public Texture2D mouseHand;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	void Start () 
	{
		cursorIsOver = false;
		buttonIsOn = false;
        drawerIsOpen = false;
		if (playerController != null) 
		{
			rfpc = playerController.GetComponent<FirstPersonController> ();
			if (rfpc == null)
				Debug.Log ("No RigidbodyFirstPersonController found");
		}
	}
	
	void Update ()
	{
		RaycastHit hit;
		ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
		if (Physics.Raycast (ray, out hit, 100.0f)) {
			if (hit.collider.tag == "Button" || hit.collider.tag == "Drawer")
            {
  //              Debug.Log("Ray is hitting the " + hit.transform.tag);
                cursorIsOver = true;
				CursorTexture(mouseHand, hotSpot);
				if (Input.GetMouseButtonDown(0)) 
				{
					Debug.Log ("You clicked a " + hit.collider);
                    if (hit.collider.tag == "Button")
                    {
                        buttonIsOn = true;
                        MakeItSo(hit.collider);
                    }
                    if (hit.collider.tag == "Drawer")
                    {
                        drawerIsOpen = true;
                        UseDrawer(hit.collider);
                    }
				}
			}
		} else {
			cursorIsOver = false;
			CursorTexture(null, hotSpot);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			ExitMinitoa ();
		}
	}

	public void ExitMinitoa()
	{
		Application.Quit();
	}
	
	void CursorTexture(Texture2D texture, Vector2 hotSpot)
	{
		Cursor.SetCursor(texture, hotSpot, cursorMode);
	}

	public void MakeItSo(Collider col)
	{
		col.GetComponent<ButtonClicker>().ToggleButton();
	}

    public void UseDrawer(Collider col)
    {
        col.GetComponent<DrawerOpener>().ToggleDrawer();

    }

}