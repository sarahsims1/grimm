using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Beginning : MonoBehaviour
{
    public AudioSource auds;
    public AudioClip momSound;
    public static Vector3 defalt;
    public Vector3 dealf;
    public bool start;

    public TMP_Text text;
    public GameObject image;

    public GameObject controller;
    public GameObject cam;

    public GameObject eGraphic;

    public delegate void LimpCont();
    public static LimpCont stopLimp;

    public CharPathManage cpm;

    public bool teleportToStart;

    private Color color;

    private void Start()
    {
        defalt = dealf;
        ResetController("Good morning darling! Here, take this basket. Your grandmother is sick, take her this bread and wine to make her feel better. Take care not to stray off the path, go straight there and back.");
    }
    public void ResetController(string text)
    {
        cpm.Restart();
        stopLimp();
        eGraphic.SetActive(true);
        if (teleportToStart)
        {
            cam.transform.parent = null;
            controller.transform.position = defalt;
            cam.transform.parent = controller.transform;
            cam.transform.localPosition = new Vector3(0, 0.8f, 0);
        }
        StartCoroutine(MomsTalking(text));
    }

    private IEnumerator MomsTalking(string momText)
    {
        bool ready = false;
        for (int i = 0; i < momText.Length; i++)
        {
            text.gameObject.SetActive(true);
            image.SetActive(true);
            color.a = 1;
            image.GetComponent<Image>().color = color;
            text.text = text.text + momText[i];
            auds.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
            auds.PlayOneShot(momSound);
            yield return new WaitForSecondsRealtime(0.05f);
            if(momText.Length - 1 == i)
            {
                ready = true;
            }
        }

        yield return new WaitUntil(() => ready == true);
        yield return new WaitForSecondsRealtime(3);
        text.text = "";
        text.gameObject.SetActive(false);
        color.a = 0;
        image.GetComponent<Image>().color = color;
    }
}
