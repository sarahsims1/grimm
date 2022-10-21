using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class stepmomevent : MonoBehaviour
{
    public Renderer stepMom;

    public Material sheGottheClip;

    public Image black;

    public AudioSource auds;
    public AudioClip ouch;
    public AudioClip sting;

    public delegate void Limp();
    public static Limp limpStart;

    public GameObject dialogObject;
    public GameObject dialog;

    static stepmomevent stme;

    public FirstPersonController fps;

    public GameObject toe;

    private Color color;

    private bool fade;

    public float fadeTime;

    public GameObject epop;
    private void Start()
    {
        stme = gameObject.GetComponent<stepmomevent>();
        color = black.color;
    }

    private void Update()
    {
        if(fade && color.a < 1)
        {
            color.a += fadeTime * Time.deltaTime;
            black.color = color;
        }
        if(!fade && color.a > 0)
        {
            color.a -= fadeTime * Time.deltaTime;
            black.color = color;
        }
    }

    public static void Fadey(bool fade)
    {
        if(fade)
        {
            fade = true;
        }
        else
        {
            fade = false;
        }
    }
    public static void Begin()
    {
        stme.StartEvent(true);
    }
    void StartEvent(bool start)
    {
        if (start)
        {
            auds.PlayOneShot(sting);
            stepMom.material = sheGottheClip;
            StartCoroutine(Uhoh());
        }
    }

    private IEnumerator Uhoh()
    {
        yield return new WaitForSecondsRealtime(2f);
        fade = true;
        color.a = 1;
        black.color = color;
        yield return new WaitForSecondsRealtime(1f);
        auds.PlayOneShot(ouch);
        yield return new WaitForSecondsRealtime(4f);

        //Activates limp script
        limpStart();
        toe.SetActive(true);
        fade = false;
        dialogObject.SetActive(false);
        dialog.SetActive(false);
        fps.Frozen(false);
        epop.SetActive(false);
    }
}
