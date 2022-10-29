using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public GameObject goodImage;
    public GameObject badImage;
    public GameObject reallyBadImage;

    public AudioSource auds;
    public Animator anime;

    public AudioClip good;
    public AudioClip nirmal;
    public AudioClip bad;

    private Color color;
    public TMP_Text text;

    public static int whichEnding = 1;
    bool fade;
    bool fadeAudio;
    void Start()
    {
        anime.SetBool("fade", true);
        color = text.color;
        color.a = 0f;
        text.color = color;
        switch (whichEnding)
        {
            case 3:
                reallyBadImage.SetActive(true);
                badImage.SetActive(false);
                goodImage.SetActive(false);
                auds.PlayOneShot(bad);
                StartCoroutine(displayText("Ending 3/3", 22f));
                break;
            case 1:
                reallyBadImage.SetActive(false);
                badImage.SetActive(false);
                goodImage.SetActive(true);
                auds.PlayOneShot(good);
                StartCoroutine(displayText("Ending 1/3", 18f));
                break;
            case 2:
                reallyBadImage.SetActive(false);
                badImage.SetActive(true);
                goodImage.SetActive(false);
                auds.PlayOneShot(nirmal);
                StartCoroutine(displayText("Ending 2/3", 18f));
                break;
            default:
                StartCoroutine(displayText("You've broken the game. I don't know how you got here", 18f));
                break;
        }
        staticStuff.goodFlags = 0;
        staticStuff.badFlags = 0;
    }

    private void Update()
    {
        if(fade)
        {
            color.a += 1f * Time.deltaTime;
            text.color = color;
        }
        if(fadeAudio)
        {
            auds.volume -= 0.5f * Time.deltaTime;
        }
    }
    private IEnumerator displayText(string text, float time)
    {
        this.text.text = text;
        yield return new WaitForSecondsRealtime(time/3f);
        fade = true;
        yield return new WaitForSecondsRealtime(time/3f);
        anime.SetBool("fade", false);
        fadeAudio = true;
        yield return new WaitForSecondsRealtime(time/3f);
        SceneManager.LoadScene("Menus");
    }
}
