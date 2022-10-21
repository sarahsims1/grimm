using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingObjectSpawn : MonoBehaviour
{
    public static bool badEnd;

    public GameObject[] normal;
    public GameObject[] bad;
    void Start()
    {
        //turns off all event specific gameobjects 
        foreach (GameObject o in bad)
        {
            o.SetActive(false);
        }
        foreach (GameObject o in normal)
        {
            o.SetActive(false);
        }

        //Depending on the ending recieved, turns specific gameobjects on
        if (badEnd)
        {
            foreach(GameObject o in bad)
            {
                o.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject o in normal)
            {
                o.SetActive(true);
            }
        }
    }
}
