using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOpener : MonoBehaviour
{
    public GameObject drawerToUse;
    public bool drawerIsOpen;
    Animator drawerAnimator;

    public delegate void clickAction(bool drawerState);
    public event clickAction OnClicked;

    void Start()
    {
        drawerAnimator = drawerToUse.GetComponent<Animator>();
        drawerIsOpen = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            CloseDrawer();
        }
    }

    public void OpenDrawer()
    {
        drawerIsOpen = true;
        OperateDrawer();
    }

    public void CloseDrawer()
    {
        drawerIsOpen = false;
        OperateDrawer();
    }

    public void ToggleDrawer()
    {
        drawerIsOpen = !drawerIsOpen;
  //      Debug.Log("drawerIsOpen is " + drawerIsOpen);
        OperateDrawer();
    }

    public void OperateDrawer()
    {
        drawerAnimator.SetTrigger("OpenDrawer");
        Debug.Log("drawerIsOpen is " + drawerIsOpen);
        if (OnClicked != null)
        {
            OnClicked(drawerIsOpen);
        }
    }
}
