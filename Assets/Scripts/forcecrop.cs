using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcecrop : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            rb.AddForce(new Vector3(-5, 5, 0), ForceMode.Impulse);
        }
    }
}
