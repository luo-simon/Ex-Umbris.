using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{

    public float minWaitTime;
    public float maxWaitTime;
    private Light2D light;

    void Start()
    {
        light = GetComponent<Light2D>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minWaitTime, maxWaitTime));
            light.enabled = !light.enabled;
        }
    }
}
