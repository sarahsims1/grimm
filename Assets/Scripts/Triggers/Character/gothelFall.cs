using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class gothelFall : MonoBehaviour
{
    Animator anime;

    public AudioSource auds;

    public AudioClip jumpScare;

    public GameObject fps;

    public GameObject startCam;

    public GameObject cam;

    public GameObject black;

    public GameObject post1;

    public GameObject post2;

    private Color color;

    private bool fade;

    int counter;
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
            fps.SetActive(false);
            startCam.SetActive(false);
            cam.SetActive(true);
            cam.GetComponent<Animator>().SetBool("fall", true);
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
        yield return new WaitForSecondsRealtime(0.5f);
        fade = false;
        yield return new WaitForSecondsRealtime(2f);
        black.SetActive(true);
        fps.GetComponent<AudioSource>().volume = 0;
        fade = true;
        color.a = 1;
        black.GetComponent<Image>().color = color;
        yield return new WaitForSecondsRealtime(4);
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
    }
}
