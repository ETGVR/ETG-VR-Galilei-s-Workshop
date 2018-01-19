using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeSprite : MonoBehaviour
{
    private Material spriteMat;
    public Material starMat;
    public Material blurryStarMat;
    public Material emptyMat;
    public TextTracker yawPosition;
    public TextTracker pitchPosition;
    private Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        spriteMat = emptyMat;
        rend.material = emptyMat;
    }

    public void ShowTheStars()
    {
        spriteMat = starMat;
        rend.material = spriteMat;
    }

    public void HideTheStars()
    {
        spriteMat = emptyMat;
        rend.material = spriteMat;
    }

    // Update is called once per frame
    void Update()
    {
        float newYawPos = yawPosition.angle / 1000f;
        float newPitchPos = pitchPosition.angle / 1000f;
        Debug.Log("yawPosition.angle/100" + newYawPos);
        spriteMat.mainTextureOffset = new Vector2(newYawPos, newPitchPos);
    }
}

