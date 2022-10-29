using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Beginning : MonoBehaviour
{
    public AudioSource auds;
    public AudioClip momSound;
    public static Vector3 defalt;
    public Vector3 dealf;
    public bool start;
    public MusicChange ms;

    public TMP_Text text;
    public GameObject image;

    public GameObject controller;
    public GameObject cam;

    public GameObject eGraphic;

    public CharPathManage cpm;

    public Brightness bright;

    public bool teleportToStart;

    private Color color;

    bool ready = false;

    bool resetting;

    float wait = 3;
    private void Start()
    {
        defalt = dealf;
        ResetController("Good morning darling! Here, take this basket. Your grandmother is sick, take her this bread and wine to make her feel better. Follow the path and don't stray, go straight there and back.");     
    }
    public void ResetController(string text)
    {
        resetting = true;
        bright.UpdateLighting();
        ms.ResetMusic();
        cpm.Restart();
        cam.GetComponent<DrunkScript>().enabled = false;
        eGraphic.SetActive(true);
        wait = 3;
        if (teleportToStart)
        {
            cam.transform.parent = null;
            controller.transform.position = defalt;
            cam.transform.parent = controller.transform;
            cam.transform.localPosition = new Vector3(0, 0.8f, 0);
            controller.GetComponent<FirstPersonController>().Frozen(true);
        }
        StartCoroutine(MomsTalking(text));
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && resetting)
        {
            ready = true;
            wait = wait - 1;
        }
    }
    private IEnumerator MomsTalking(string momText)
    {
        image.SetActive(true);
        color.a = 1;
        image.GetComponent<Image>().color = color;
        for (int i = 0; i < momText.Length; i++)
        {
            if (ready == false)
            {
                text.gameObject.SetActive(true);
                text.text = text.text + momText[i];
                auds.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
                auds.PlayOneShot(momSound);
                yield return new WaitForSecondsRealtime(0.04f);
                if (momText.Length - 1 == i)
                {
                    ready = true;
                }
            }
        }

        yield return new WaitUntil(() => ready == true);
        text.text = momText;

        yield return new WaitForSecondsRealtime(3);
        text.text = "";
        text.gameObject.SetActive(false);
        color.a = 0;
        image.GetComponent<Image>().color = color;
        controller.GetComponent<FirstPersonController>().Frozen(false);
        ready = false;
        resetting = false;
    }
}
