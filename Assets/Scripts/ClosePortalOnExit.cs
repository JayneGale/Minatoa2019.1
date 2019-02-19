using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePortalOnExit : MonoBehaviour {
    public GameObject portalButton1;
    public GameObject portalButton2;
    public GameObject portal;
    Animator portalAnimator;
    public bool isOpening;

    private void Start()
    {
        portalAnimator = portal.GetComponent<Animator>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            portalButton1.GetComponent<ButtonClicker>().DeactivateButton();
            portalButton2.GetComponent<ButtonClicker>().DeactivateButton();
            isOpening = false;
            portalAnimator.SetBool("isOpening", isOpening);
        }
    }
}
