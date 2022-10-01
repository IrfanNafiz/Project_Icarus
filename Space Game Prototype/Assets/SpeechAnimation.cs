using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechAnimation : MonoBehaviour
{
    public RectTransform[] images;

    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < images.Length; i ++) {
            images[i].sizeDelta = new Vector2(10, 100 * Mathf.PerlinNoise(i * 10, t * 5));
        }

        t += Time.deltaTime;
    }
}
