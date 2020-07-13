using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Blackout : MonoBehaviour
{
    public bool blackout = true;

    private Image image;

    public float fadeAmount;

    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine("Fade");
    }

    public IEnumerator Fade()
    {
        if (blackout)
        {
            float i = 255;
            while (i > 0)
            {
                image.color = new Color32(0, 0, 0, (byte)i);
                i -= fadeAmount;
                yield return null;
            }
            if (image.color.a <= 1)
            {
                blackout = !blackout;
            }
        } else
        {
            float i = 0;
            while (i < 255)
            {
                image.color = new Color32(0, 0, 0, (byte)i);
                i += fadeAmount;
                yield return null;
            }
            if (image.color.a >= 250)
            {
                blackout = !blackout;
            }
        }
        yield return null;
    }
}
