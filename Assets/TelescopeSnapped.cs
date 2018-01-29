using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class TelescopeSnapped : MonoBehaviour {
    public TelescopeSprite telescopeSprite;
    public TelescopeController telescopeCylinder;
    private WorkbenchManager workbench;

	void Start () {
        workbench = GameObject.FindObjectOfType<WorkbenchManager>();
        GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += Snapped;
        GetComponent<VRTK_SnapDropZone>().ObjectUnsnappedFromDropZone += Unsnapped;
    }

    private void Snapped(object sender, SnapDropZoneEventArgs e)
    {
        Debug.Log("Telescope snapped, show us the stars");
        telescopeSprite.ShowTheStars();
        telescopeCylinder.isStargazing = true;
    }

    private void Unsnapped(object sender, SnapDropZoneEventArgs e)
    {
        Debug.Log("Telescope was usnapped, show us the void");
        telescopeSprite.HideTheStars();
        telescopeCylinder.isStargazing = false;
    }
}
