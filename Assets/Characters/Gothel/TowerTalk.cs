using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using Doublsb.Dialog;

public class TowerTalk : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    public GameObject hair;

    public GameObject fps;

    public GameObject camera;

    public GameObject basket;

    public GameObject gothTrig;

    private bool climb;

    private float time;

    public float maxTime;

    public Vector3 towerBottom;

    public Quaternion towerRot;

    int counter;

    int counter2;

    public AudioSource auds;

    public AudioSource madman;

    public AudioClip climbing;

    public GameObject epop;

    public MusicChange ms;
    private void Awake()
    {
        Talk.talking += ShowYourself;
        hair.SetActive(false);
    }

    private void Update()
    {
        if(climb)
        {
            StartCoroutine(ms.ChangeMusicFade("none", 1f));
            time += Time.deltaTime;
        }
        if(time>maxTime && fps.transform.position != transform.position)
        {
              fps.GetComponent<FirstPersonController>().enabled = false;
              fps.transform.position = Vector3.Lerp(fps.transform.position, transform.position, 0.1f);
              fps.transform.rotation = Quaternion.Lerp(fps.transform.rotation, transform.rotation, 0.1f);
              counter2++;
        }
        if(time > maxTime && counter == 0)
        {
            auds.PlayOneShot(climbing);
            camera.GetComponent<Animator>().enabled = true;
            camera.GetComponent<Animator>().SetBool("climb", true);
            basket.GetComponent<Animator>().enabled = true;
            basket.GetComponent<Animator>().SetBool("drop", true);
            counter++;
        }
    }
    private void ShowYourself()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("*A tower rises above the forest*", "Wolf"));

        var Text1 = new DialogData("???","Wolf");
        Text1.SelectList.Add("Polite", "Rapunzel, Rapunzel, let down your hair!");
        Text1.SelectList.Add("Mean", "...");

        Text1.Callback = () => Check_Response();
        Talk.selectActive = true;

        dialogTexts.Add(Text1);

        DialogManager.Show(dialogTexts);
    }

    private void Check_Response()
    {

        Talk.selectActive = false;

        if (DialogManager.Result == "Polite")
        {
            staticStuff.runSoured = true;
            hair.SetActive(true);
            hair.GetComponent<Animator>().SetBool("start", true);
            madman.enabled = false;
            climb = true;
            epop.SetActive(false);
            fps.GetComponent<FirstPersonController>().Frozen(false);
        }

        else if (DialogManager.Result == "Mean")
        {

            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("...", "Wolf"));

            DialogManager.Show(dialogTexts);
        }
    }
  
}
