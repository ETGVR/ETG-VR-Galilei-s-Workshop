using UnityEngine;
using System.Collections;

public class StripScroller : MonoBehaviour
{
    //public Vector2 offset;
    //public Vector2 textureScale;

    private Renderer rend;
    private Vector2 savedOffset;
    private Vector3 startPosition;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startPosition = transform.position;
        savedOffset = rend.sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        //rend.material.mainTextureScale = textureScale;
        //rend.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        //rend.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
