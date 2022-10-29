using System;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{
    public delegate void clicked();
    public static clicked click;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            try
            {
                click.Invoke();
            }
            catch(NullReferenceException err)
            {
                Debug.Log("No buttons to select :(");
                Debug.Log(err.Message);
            }
        }
    }
}
