using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeSprite : MonoBehaviour
{
    private Material spriteMat;
    private TelescopeConstruction telescope;
    public Material starMat;
    public Material blurryMat;
    public Material emptyMat;
    public TextTracker yawPosition;
    public TextTracker pitchPosition;
    private Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        telescope = GameObject.FindObjectOfType<TelescopeConstruction>();
        spriteMat = emptyMat;
        rend.material = emptyMat;
    }

    public void ShowTheStars()
    {
        if (telescope.IsCorrectlyConstructed())
        {
            spriteMat = starMat;
        }
        else
        {
            spriteMat = blurryMat;
        }
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
        spriteMat.mainTextureOffset = new Vector2(newYawPos, newPitchPos);
    }
}

