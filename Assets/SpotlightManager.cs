using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightManager : MonoBehaviour
{
    private Light[] spots = new Light[3];
    private float maxSpotIntensity;
    private int currentSpot;
    private float speed = 1.37f;

    // Use this for initialization
    void Start()
    {
        spots[0] = GameObject.FindGameObjectWithTag("Spot1").GetComponent<Light>();
        spots[1] = GameObject.FindGameObjectWithTag("Spot2").GetComponent<Light>();
        spots[2] = GameObject.FindGameObjectWithTag("Spot3").GetComponent<Light>();
        maxSpotIntensity = spots[0].intensity;
        // reset spot intensity
        foreach (Light spot in spots)
        {
            spot.intensity = 0;
        }
        // fade in first spot
        FadeIn(0);
    }

    public void Next()
    {
        FadeOut(currentSpot);
        currentSpot++;
        FadeIn(currentSpot);
    }

    private void FadeIn(int spotIndex)
    {
            StartCoroutine(Fade(maxSpotIntensity, spotIndex));
    }

    private void FadeOut(int spotIndex)
    {
        StartCoroutine(Fade(0, spotIndex));
    }

    private IEnumerator Fade(float targetValue, int spotIndex)
    {
        if (spotIndex < spots.Length)
        {
            Light spot = spots[spotIndex];
            float startingIntensity = spot.intensity;
            float t = 0;
            while (!Mathf.Approximately(spot.intensity, targetValue))
            {
                t += (Time.deltaTime) * speed;
                spot.intensity = Mathf.Lerp(startingIntensity, targetValue, t);
                Debug.Log("t: " + t);
                Debug.Log(spot.intensity);
                yield return new WaitForEndOfFrame();
            }
        }
        yield return 0;
    }
}
