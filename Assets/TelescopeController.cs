using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeController : MonoBehaviour {
    public TextTracker yawPosition;
    public TextTracker pitchPosition;
    private Vector3 originalRotation;
    public float scalingFactor = 100;
    public bool isStargazing;

    private void Start()
    {
        originalRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update () {
        if (isStargazing)
        {
            transform.eulerAngles = new Vector3(originalRotation.x - pitchPosition.angle / scalingFactor, originalRotation.y + yawPosition.angle / scalingFactor, originalRotation.z);
        }
	}
}
