using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class OnExperimentSnap : MonoBehaviour
{
    private GameObject experimentalSetup;
    private GameObject telescope;
    private VRTK_ObjectAutoGrab autoGrabber;

    void Start()
    {
        experimentalSetup = GameObject.FindGameObjectWithTag("ExperimentalSetup");
        autoGrabber = GameObject.FindGameObjectWithTag("MainController").GetComponent<VRTK_ObjectAutoGrab>();
        GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += TelescopeSnapped;
        GetComponent<VRTK_SnapDropZone>().ObjectUnsnappedFromDropZone += TelescopeUnsnapped;
    }

    private void TelescopeUnsnapped(object sender, SnapDropZoneEventArgs e)
    {
    }

    private void TelescopeSnapped(object sender, SnapDropZoneEventArgs e)
    {
        experimentalSetup.SetActive(true);
        // disable the phyiscal/carry-around telescope so that we don't accidentally grab 
        // it when experimenting on the workbench telescope
        GameObject.FindObjectOfType<TelescopeController>().gameObject.SetActive(false);
        autoGrabber.enabled = false;
    }
}
