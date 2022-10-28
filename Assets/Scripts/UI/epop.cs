using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class epop : MonoBehaviour
{
    [SerializeField]
    private GameObject e;

    [SerializeField]
    public static float offSet;

    [SerializeField]
    private float fadeSpeed;

    private GameObject currentChar;

    private Color color;

    private void Start()
    {
        offSet = 3;
        color = e.GetComponent<SpriteRenderer>().color;
        color.a = 0;
    }
    private void Update()
    {
        if(currentChar != null)
        {
            if(e.GetComponent<SpriteRenderer>().color.a < 1)
            {
                color.a += fadeSpeed * Time.deltaTime;
                e.GetComponent<SpriteRenderer>().color = color;
            }
            e.transform.LookAt(gameObject.transform);
        }
        else if(e.GetComponent<SpriteRenderer>().color.a > 0)
        {
            color.a -= fadeSpeed * Time.deltaTime;
            e.GetComponent<SpriteRenderer>().color = color;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Frog"))
        {
            offSet = 4;
            currentChar = other.gameObject;
            e.transform.parent = currentChar.transform;
            e.transform.localPosition = new Vector3(offSet, 0, 0);
        }
        if (other.tag.Equals("character"))
        {
            offSet = 3;
            currentChar = other.gameObject;
            e.transform.parent = currentChar.transform;
            e.transform.localPosition = new Vector3(offSet, 0, 0);
        }
        if (other.tag.Equals("tower"))
        {
            offSet = 0;
            currentChar = other.gameObject;
            e.transform.parent = currentChar.transform;
            e.transform.localPosition = new Vector3(offSet, 0, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Frog") || other.tag.Equals("character") || other.tag.Equals("tower"))
        {
            currentChar = null;
        }
    }
}
