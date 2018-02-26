using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HotkeyManager : MonoBehaviour {
    private SpotlightManager spotman;

    private void Start()
    {
        spotman = GameObject.FindObjectOfType<SpotlightManager>();
    }

    void Update () {
        // restart the scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Restart the scene!");
            SceneManager.LoadSceneAsync(0);
        } else if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Trigger the next spotlight!");
            spotman.Next();
        }
		
	}
}
