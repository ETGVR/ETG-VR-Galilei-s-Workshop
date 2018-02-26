using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour {
    public LeverTracker lever;
    private GameObject hatch;
    private HingeJoint hinge;
    private GameObject wheel;
    // Use this for initialization
    void Awake () {
        hinge = GetComponent<HingeJoint>();

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
        hingeSpring.targetPosition = lever.angle * 4;
        hinge.spring = hingeSpring;
        hinge.useSpring = true;
    }
}
