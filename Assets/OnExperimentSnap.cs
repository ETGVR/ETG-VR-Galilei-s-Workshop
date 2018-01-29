using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class OnExperimentSnap : MonoBehaviour
{
    private WorkbenchManager workbench;

    void Start()
    {
        workbench = GameObject.FindObjectOfType<WorkbenchManager>();
        GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += TelescopeSnapped;
        GetComponent<VRTK_SnapDropZone>().ObjectUnsnappedFromDropZone += TelescopeUnsnapped;
    }

    private void TelescopeUnsnapped(object sender, SnapDropZoneEventArgs e) { }

    private void TelescopeSnapped(object sender, SnapDropZoneEventArgs e)
    {
        workbench.ShowWorkbench();
    }
}
