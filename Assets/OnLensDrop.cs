using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class OnLensDrop : MonoBehaviour
{
    private int lensIndex;
    private TelescopeConstruction telescope;

    void Start()
    {
        lensIndex = int.Parse(name.Split('-')[1]);
        telescope = GameObject.FindObjectOfType<TelescopeConstruction>();
        GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += LensSlotted;
        GetComponent<VRTK_SnapDropZone>().ObjectUnsnappedFromDropZone += LensUnslotted;
    }

    private void LensUnslotted(object sender, SnapDropZoneEventArgs e)
    {
        telescope.SetLens(lensIndex, TelescopeConstruction.LENSES.None);
    }

    private void LensSlotted(object sender, SnapDropZoneEventArgs e)
    {
        Debug.Log("a lens has been snapped to the drop zone!");
        Debug.Log(e.snappedObject.GetComponent<LensType>().type);
        Debug.Log(e.snappedObject);
        telescope.SetLens(lensIndex, e.snappedObject.GetComponent<LensType>().type);
    }
}
