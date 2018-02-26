using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HotkeyManager : MonoBehaviour {
	
	void Update () {
        // restart the scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Restart the scene!");
            SceneManager.LoadSceneAsync(0);
        }
		
	}
}
