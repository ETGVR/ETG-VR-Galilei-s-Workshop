using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class WorkbenchManager : MonoBehaviour {
    private GameObject telescope;
    private GameObject workbenchVisuals;
    private GameObject[] lensesInBench  = new GameObject[3];
    private GameObject emptyObject;
    private VRTK_ObjectAutoGrab grabber;
    private TelescopeConstruction scopeConstruction;
    private Vector3 SPAWN_POSITION = new Vector3(-100, -100, -100);

    private GameObject telescopeCover;
    private Transform telescopeCoverTransform;

    private void Start()
    {
        workbenchVisuals = GameObject.FindGameObjectWithTag("ExperimentalSetup");
        emptyObject = GameObject.FindGameObjectWithTag("EmptyObject");
        grabber = GameObject.FindGameObjectWithTag("MainController").GetComponent<VRTK_ObjectAutoGrab>();
        telescope = GameObject.FindGameObjectWithTag("Telescope");
        scopeConstruction = GameObject.FindObjectOfType<TelescopeConstruction>();
        // initialize bench lenses array
        for (int i = 0; i < lensesInBench.Length; i++) { lensesInBench[i] = emptyObject;}

        telescopeCover = GameObject.FindGameObjectWithTag("TelescopeCover");
        telescopeCoverTransform = GameObject.FindGameObjectWithTag("TelescopeCoverPosition").transform;
    }

    public void ShowWorkbench()
    {
        SetVisibility(true);

        // disable the telescope and place it out of harms way 
        grabber.enabled = false;
        telescope.GetComponent<Renderer>().enabled = false;
        telescope.transform.position = SPAWN_POSITION;

        // reset the telescope cover position
        telescopeCover.transform.position = telescopeCoverTransform.position;
        telescopeCover.transform.rotation = telescopeCoverTransform.rotation;
    }

    public void RegisterLens(int index, LensType lens)
    {
        lensesInBench[index] = lens.gameObject;
        scopeConstruction.SetLens(index, lens.type);
    }

    public void RemoveLens(int index)
    {
        lensesInBench[index] = emptyObject;
        scopeConstruction.SetLens(index, TelescopeConstruction.LENSES.None);
    }

    public void HideWorkbench()
    {
        SetVisibility(false);

        // activate the telescope
        telescope.GetComponent<Renderer>().enabled = true;
        // place it in the player's main hand
        grabber.enabled = true;
    }

    private void SetVisibility(bool isVisible)
    {
        // hide the workbench area
        workbenchVisuals.SetActive(isVisible);

        // hide any lenses that are in the workbench
        foreach (GameObject lens in lensesInBench) {
            lens.GetComponent<Renderer>().enabled = isVisible;
        }
    }
}
