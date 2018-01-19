using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class TelescopeSnapped : MonoBehaviour {
    public TelescopeSprite telescope;
    public GameObject experimentalSetup;

	void Start () {
        GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += Snapped;
        GetComponent<VRTK_SnapDropZone>().ObjectUnsnappedFromDropZone += Unsnapped;
    }

    private void Snapped(object sender, SnapDropZoneEventArgs e)
    {
        Debug.Log("Telescope snapped, show us the stars");
        telescope.ShowTheStars();
        //experimentalSetup.SetActive(false);
    }

    private void Unsnapped(object sender, SnapDropZoneEventArgs e)
    {
        Debug.Log("Telescope was usnapped, show us the void");
        telescope.HideTheStars();
        //experimentalSetup.SetActive(true);
    }
}
