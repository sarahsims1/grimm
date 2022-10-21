using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacle : MonoBehaviour
{
    public int length = 20;
    public LineRenderer lr;
    public Vector3[] segementpos;
    private Vector3[] segmentV;

    public float targetDist;
    public float smoothSpeed;
    public float gravity;

    public Vector3 distKept;

    public Transform targetDir;
    private void Start()
    {
        lr.positionCount = length;
        segementpos = new Vector3[length];
        segmentV = new Vector3[length];

        for (int i = 0; i < segementpos.Length; i++)
        {
            segementpos[i] = targetDir.position; ;
        }
        lr.SetPositions(segementpos);
    }

    private void Update()
    {
        segementpos[0] = targetDir.position;

        for (int i = 1; i < segementpos.Length; i++)
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0;
            Vector3[] v = new Vector3[2];
            v[0] = mouse;
            v[1] = segementpos[i - 1];
            Vector3 newPos = CenterOfVectors(v);
            segementpos[i] = Vector3.SmoothDamp(segementpos[i], segementpos[i - 1] - (new Vector3(0, gravity, 0)) + (mouse * 0.05f) + targetDir.right * targetDist, ref segmentV[i], smoothSpeed); 
        }
        lr.SetPositions(segementpos);
    }

    public Vector3 CenterOfVectors(Vector3[] vectors)
    {
        Vector3 sum = Vector3.zero;
        if (vectors == null || vectors.Length == 0)
        {
            return sum;
        }

        foreach (Vector3 vec in vectors)
        {
            sum += vec;
        }
        return sum / vectors.Length;
    }
}
