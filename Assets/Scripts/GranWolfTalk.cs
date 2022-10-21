using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Doublsb.Dialog;
using UnityEngine.UI;

public class GranWolfTalk : MonoBehaviour
{
    public GameObject granwolf;

    private Renderer normalMat;

    public Material scaryMat;

    public GameObject player;

    public float spped;

    private bool start;

    public DialogManager DialogManager;

    public GameObject[] Example;

    public float time;

    private string [] s = new string[3];

    public Image black;

    private void Awake()
    {
        normalMat = granwolf.GetComponent<Renderer>();
        GranTalk.talking += ShowYourself;
        s[0] = "Why Granny, what big eyes you have.";
        s[1] = "Why Granny, what big ears you have.";
        s[2] = "Why Granny, what big teeth you have.";
    }

    private void ShowYourself()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Hello, Little Red.", "Wolf"));

        var Text1 = new DialogData("How are you?", "Wolf");

        for (int i = 0; i < s.Length; i++)
        {
            Text1.SelectList.Add(i.ToString(), s[i]);
        }

        GranTalk.selectActive = true;

        dialogTexts.Add(Text1);

        DialogManager.Show(dialogTexts);

        StartCoroutine(YouveBeenChomped());
    }

    private void Update()
    {
        if(start)
        {
            normalMat.material = scaryMat;
            granwolf.transform.position = Vector3.MoveTowards(granwolf.transform.position, player.transform.position, spped);
        }
    }
    private IEnumerator YouveBeenChomped()
    {
        yield return new WaitForSecondsRealtime(time);
        start = true;
        yield return new WaitForSecondsRealtime(0.5f);
        Color color = new Color(0,0,0);
        black.color = color;
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("goodEnding");
    }
}
