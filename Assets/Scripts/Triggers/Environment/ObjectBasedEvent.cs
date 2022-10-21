using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBasedEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject triggerObject;

    [SerializeField]
    private GameObject[] g;

    [SerializeField]
    private GameObject[] o;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player") || other.gameObject.tag.Equals("MainCamera") && triggerObject.activeSelf)
        {
            foreach (GameObject objec in g)
            {
                objec.SetActive(true);
            }
            foreach (GameObject objec in o)
            {
                objec.SetActive(false);
            }
        }
    }
}
