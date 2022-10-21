using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeHair : MonoBehaviour
{
    // Start is called before the first frame update
    bool ready;

    Color color;

    float time;
    public float maxTime;
    public float fadeTime;

    new Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        color = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>maxTime&&color.a<1)
        {
            color.a += fadeTime * Time.deltaTime;
            renderer.material.color = color;
        }
    }
}
