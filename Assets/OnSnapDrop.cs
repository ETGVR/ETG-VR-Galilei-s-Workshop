using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class OnSnapDrop : MonoBehaviour {
    private WorkbenchManager workbench;

	void Start () {
        GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += TelescopeGrabbed;
        workbench = GameObject.FindObjectOfType<WorkbenchManager>();
    }

    private void TelescopeGrabbed(object sender, SnapDropZoneEventArgs e)
    {
        Debug.Log("the item has been snapped to the drop zone!");
        workbench.HideWorkbench();
    }
}
