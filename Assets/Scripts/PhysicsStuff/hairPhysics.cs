using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hairPhysics : MonoBehaviour
{
    public int length;
    public LineRenderer lr;
    public Vector3[] segments;
    private Vector3[] segementV;

    public Transform targetDir;
    public Transform anchor;
    public float targetDist;
    public float smoothSpeed;
    void Start()
    {
        //Initializing positions
        lr.positionCount = length;
        segments = new Vector3[length];
        segementV = new Vector3[length];

        //Setting positions to start out. This ensures that they are in the right place when the game starts
        segments[0] = targetDir.position;

        for (int i = 1; i < segments.Length - 1; i++)
        {
            segments[i] = targetDir.position;
        }
        segments[segments.Length - 1] = anchor.position;
        lr.SetPositions(segments);
    }

    void Update()
    {
        //Same code, but in update
        //First segment goes on the moving compnent
        segments[0] = targetDir.position;

        //For loop to determine the position of each point
        for (int i = 1; i < segments.Length - 1; i++)
        {
            //Determines two vectors based on the position of the anchor and the target
            Vector3[] v = new Vector3[2];
            v[0] = (segments[i + 1] - anchor.right * targetDist);
            v[1] = (segments[i - 1] + targetDir.right * targetDist);

            //Then find the center of those vecotrs, and moves towards them
            segments[i] = Vector3.SmoothDamp(segments[i],  CenterOfVectors(v), ref segementV[i], smoothSpeed);
        }
        segments[segments.Length - 1] = anchor.position;
        lr.SetPositions(segments);
    }

    //Method to determine the center of vectors
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
