using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTracker : MonoBehaviour {
    private float startAngle;
    private Transform wheel;
    public Text textBox;

    private void Awake()
    {
        wheel = gameObject.transform;
        startAngle = wheel.rotation.eulerAngles.x;
    }

    private float angle;
    void FixedUpdate () {

        angle = Mod(Mathf.CeilToInt(wheel.rotation.eulerAngles.x - startAngle), 360);
        textBox.text = "" + angle;
    }

    int Mod(int a, int b)
    {
        return (a % b + b) % b;
    }
}
