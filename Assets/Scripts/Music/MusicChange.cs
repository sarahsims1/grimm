using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
    public static AudioSource auds;

    public float volume = 0.5f;

    public AudioClip regMusic;

    public AudioClip uhohMusic;

    public AudioClip badMusic;

    public AudioClip worseMusic;

    private bool fade;

    public float fadeSpeed = 1f;
    void Start()
    {
        auds = GetComponent<AudioSource>();
        auds.playOnAwake = true;
        auds.loop = true;
    }

    private void Update()
    {
        if(fade && auds.volume > 0)
        {
            auds.volume -= fadeSpeed * Time.deltaTime;
        }
        if(!fade && auds.volume < volume)
        {
            auds.volume += fadeSpeed * Time.deltaTime;
        }
    }

    //Resets music at the beginning of the run based on tone.
    public void ResetMusic()
    {
        switch (staticStuff.getRuns() - staticStuff.goodFlags)
        {
            case 0:
                if (staticStuff.goodFlags == 1)
                {
                    StartCoroutine(ChangeMusicFade("none", 1f));
                }
                else
                {
                    StartCoroutine(ChangeMusicFade("regular", 1f));
                }
                break;

            case 1:
                StartCoroutine(ChangeMusicFade("uhoh", 1f));
                break;

            case 3:
                StartCoroutine(ChangeMusicFade("bad", 1f));
                break;

            case 4:
                StartCoroutine(ChangeMusicFade("worse", 1f));
                break;

            default:
                break;
        }

    }

    //Manual music resetting for specific moments
    public IEnumerator ChangeMusicFade(string which, float fadeSpeed)
    {
        this.fadeSpeed = fadeSpeed;
        fade = true;
        yield return new WaitUntil(() => auds.volume == 0);
        switch(which)
        {
            case "regular":
                auds.clip = regMusic;
                auds.Play();
                fade = false;
                break;
            case "uhoh":
                auds.clip = uhohMusic;
                auds.Play();
                fade = false;
                break;
            case "bad":
                auds.clip = badMusic;
                auds.Play();
                fade = false;
                break;
            case "worse":
                auds.clip = worseMusic;
                auds.Play();
                fade = false;
                break;
            case "none":
                auds.Stop();
                fade = false;
                break;
            case "same":
                auds.Stop();
                auds.Play();
                fade = false;
                break;
            default:
                auds.clip = regMusic;
                auds.Play();
                fade = false;
                break;
        }
    }
    public IEnumerator ChangeMusicFade(AudioClip toPlay, float fadeSpeed)
    {
        this.fadeSpeed = fadeSpeed;
        fade = true;
        yield return new WaitUntil(() => auds.volume == 0);
        auds.clip = toPlay;
        auds.Play();
        fade = false;
    }

}
