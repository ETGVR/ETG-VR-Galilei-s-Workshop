using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class OnSnapDrop : MonoBehaviour {
    public GameObject telescope;
    public GameObject experimentalSetup;

	void Start () {
        GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += TelescopeGrabbed;
    }

    private void TelescopeGrabbed(object sender, SnapDropZoneEventArgs e)
    {
        Debug.Log("the item has been snapped to the drop zone!");
        // activate the telescope
        telescope.SetActive(true);
        // place it in the player's main hand
        GameObject.FindGameObjectWithTag("MainController").GetComponent<VRTK_ObjectAutoGrab>().enabled = true;
        // hide the experimental setup
        experimentalSetup.SetActive(false);
    }
}
