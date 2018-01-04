using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour {
    private GameObject hatch;
    private HingeJoint hinge;
    private GameObject wheel;
    private TextTracker textTracker;
    // Use this for initialization
    void Awake () {
        hinge = GetComponent<HingeJoint>();

        wheel = GameObject.Find("RotationalCylinder");
        textTracker = wheel.GetComponent<TextTracker>();

        JointSpring hingeSpring = hinge.spring;
        hingeSpring.spring = 10;
        hingeSpring.damper = 3;
        hingeSpring.targetPosition = 20;
        hinge.spring = hingeSpring;
        hinge.useSpring = true;


    }
	
	// Update is called once per frame
	void Update () {
        JointSpring hingeSpring = hinge.spring;
        hingeSpring.targetPosition = textTracker.angle / 4;
        hinge.spring = hingeSpring;
        hinge.useSpring = true;
    }
}
