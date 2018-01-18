using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeSprite : MonoBehaviour
{
    private Material spriteMat;
    public TextTracker yawPosition;
    public TextTracker pitchPosition;
    private Vector2 offset;

    // Use this for initialization
    void Start()
    {
        spriteMat = GetComponent<Renderer>().material;
        offset = spriteMat.mainTextureOffset;
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

