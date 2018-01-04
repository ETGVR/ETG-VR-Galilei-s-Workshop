using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTracker : MonoBehaviour {
    private float startAngle;
    private Transform wheel;
    public Text textBox;
    public float angle;
    private Vector3 lastFwd;
    private float curAngleX;
    private void Awake()
    {
        wheel = gameObject.transform;
        startAngle = wheel.rotation.eulerAngles.x;
    }

    void FixedUpdate()
    {
        //angle = Mod(Mathf.CeilToInt(wheel.rotation.eulerAngles.x - startAngle), 360);
        //textBox.text = "" + angle;

        Vector3 curFwd = transform.forward;
        //neg for correct orientation
        float ang = -Vector3.SignedAngle(curFwd, lastFwd, transform.up);
        angle += ang; 
        lastFwd = curFwd; 
        textBox.text = "" + Mathf.CeilToInt(angle);
    }

    int Mod(int a, int b)
    {
        return (a % b + b) % b;
    }
}
