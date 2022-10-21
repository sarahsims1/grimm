using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullHair : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance;
    new Camera camera;




    void Start()
    {
        Camera.SetupCurrent(camera);
        camera = GetComponent<Camera>();
        float[] distances = new float[32];
        distances[8] = distance;
        camera.layerCullDistances = distances;
    }
}
