using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class gothelFall : MonoBehaviour
{
    Animator anime;

    public AudioSource auds;

    public AudioSource auds2; 

    public AudioClip jumpScare;

    public AudioClip fall;

    public AudioClip tinitus;

    public GameObject fps;

    public GameObject startCam;

    public GameObject cam;

    public GameObject black;

    public GameObject post1;

    public GameObject post2;

    private Color color;

    private bool fade;

    int counter;

    public MusicChange ms;
    void Start()
    {
        anime = GetComponent<Animator>();
        color = black.GetComponent<Image>().color;
    }

    void Update()
    {
        if (anime.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("jumpScareJump") && counter == 0)
        {
            auds.PlayOneShot(jumpScare);
            counter++;
        }
        if (anime.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("jumpScareStop") && counter == 1)
        {
            GetComponent<MeshRenderer>().enabled = false;
            counter++;
            StartCoroutine(FallingDown());
        }

        if(fade)
        {
            color.a += 0.5f * Time.deltaTime;
            black.GetComponent<Image>().color = color;
        }
        if(!fade)
        {
            color.a -= 0.5f * Time.deltaTime;
            black.GetComponent<Image>().color = color;
        }
    }
    private IEnumerator FallingDown()
    {
        black.SetActive(true);
        fade = true;
        color.a = 1;
        black.GetComponent<Image>().color = color;
        yield return new WaitForSecondsRealtime(1f);
        fps.SetActive(false);
        startCam.SetActive(false);
        cam.SetActive(true);
        cam.GetComponent<Animator>().SetBool("fall", true);
        fade = false;
        yield return new WaitForSecondsRealtime(2f);
        black.SetActive(true);
        auds2.PlayOneShot(fall);
        fade = true;
        color.a = 1;
        black.GetComponent<Image>().color = color;
        yield return new WaitForSecondsRealtime(4);
        fps.GetComponent<AudioSource>().volume = 0;
        fps.SetActive(true);
        fps.GetComponent<FirstPersonController>().enabled = true;
        startCam.SetActive(true);
        cam.SetActive(false);
        startCam.GetComponent<DrunkScript>().enabled = true;
        Destroy(startCam.GetComponent<Animator>());
        startCam.transform.parent = fps.transform;
        startCam.transform.localPosition = new Vector3(0, 0.8f, 0);
        startCam.transform.localRotation = new Quaternion(0, 0, 0, 0);
        post1.SetActive(false);
        post2.SetActive(true);
        fps.GetComponent<FirstPersonController>().SetWalkSpeed(3);
        fps.GetComponent<LimpBob>().StartTheLimp();
        fade = false;
        yield return new WaitForSecondsRealtime(1);
        fps.GetComponent<AudioSource>().volume = 1;
        auds2.clip = tinitus;
        auds2.Play();
        StartCoroutine(ms.ChangeMusicFade("worse", 1f));
        auds2.loop = true;
    }
}
