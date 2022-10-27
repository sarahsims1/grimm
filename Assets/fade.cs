using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{
    void Start()
    {
        GetComponent<Animator>().SetBool("fade", true);
    }
}
