using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class flowers : MonoBehaviour
{
    bool inField;

    static int counter;

    public AudioClip pick;

    public AudioSource auds;

    public SpriteRenderer graphic;

    public GameObject flower;

    private Color color;

    private bool fade;

    public float fadeSpeed;
    private void Start()
    {
        color = graphic.color;
    }
    private void Update()
    {
        if(fade && color.a < 1)
        {
            color.a += fadeSpeed * Time.deltaTime;
            graphic.color = color;
        }
        if (!fade && color.a > 0)
        {
            color.a -= fadeSpeed * Time.deltaTime;
            graphic.color = color;
        }

        if(inField && Input.GetKeyDown(KeyCode.E))
        {
            auds.PlayOneShot(pick);
            fade = true;
            staticStuff.runSoured = true;
            flower.SetActive(true);
            fade = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            fade = true;
            inField = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(fade == false)
        {
            graphic.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        if (other.tag.Equals("Player"))
        {
            fade = false;
            inField = false;
        }
    }
}
