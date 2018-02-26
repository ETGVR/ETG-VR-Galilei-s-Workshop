using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class OnLensDrop : MonoBehaviour
{
    private int lensIndex;
    private WorkbenchManager workbench;

    void Start()
    {
        workbench = GameObject.FindObjectOfType<WorkbenchManager>();
        lensIndex = int.Parse(name.Split('-')[1]);
        GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += LensSlotted;
        GetComponent<VRTK_SnapDropZone>().ObjectUnsnappedFromDropZone += LensUnslotted;
    }

    private void LensUnslotted(object sender, SnapDropZoneEventArgs e)
    {
        workbench.RemoveLens(lensIndex);
    }

    private void LensSlotted(object sender, SnapDropZoneEventArgs e)
    {
        Debug.Log("a lens has been snapped to the drop zone! the type was " + e.snappedObject.GetComponent<LensType>().type);
        workbench.RegisterLens(lensIndex, e.snappedObject.GetComponent<LensType>());
    }
}
