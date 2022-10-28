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

    public AudioClip good;
    public AudioClip nirmal;
    public AudioClip bad;

    private Color color;
    public TMP_Text text;

    public static int whichEnding = 1;
    bool fade;
    void Start()
    {
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
                StartCoroutine(displayText("Ending 3/3"));
                break;
            case 1:
                reallyBadImage.SetActive(false);
                badImage.SetActive(false);
                goodImage.SetActive(true);
                auds.PlayOneShot(good);
                StartCoroutine(displayText("Ending 1/3"));
                break;
            case 2:
                reallyBadImage.SetActive(false);
                badImage.SetActive(true);
                goodImage.SetActive(false);
                auds.PlayOneShot(nirmal);
                StartCoroutine(displayText("Ending 2/3"));
                break;
            default:
                StartCoroutine(displayText("You've broken the game. I don't know how you got here", 18f));
                break;
        }
    }

    private void Update()
    {
        if(fade)
        {
            color.a += 1f * Time.deltaTime;
            text.color = color;
        }
    }
    private IEnumerator displayText(string text)
    {
        this.text.text = text;
        yield return new WaitForSecondsRealtime(3f);
        fade = true;
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene("Menus");
    }
}
