using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class WolfTalk : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    [SerializeField]
    private GameObject flowerPatch;


    private void Awake()
    {
        Talk.talking += ShowYourself;
    }
    private void ShowYourself()
    {

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Hello, Red."));

        var Text1 = new DialogData("How are you?");

        Text1.SelectList.Add("Polite", "I'm well, thank you.");

        Text1.SelectList.Add("Mean", "AHHH, A wolf!!!");

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
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("That's good to hear."));

            dialogTexts.Add(new DialogData("Why so solemn, though? You act like you're walking to school."));

            dialogTexts.Add(new DialogData("It's a beautiful day! Why not pause for a bit and pick a few of these lovely flowers?"));

            flowerPatch.SetActive(true);

            DialogManager.Show(dialogTexts);

        }

        else if (DialogManager.Result == "Mean")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("Ah, sorry. Didn't mean to alarm you."));

            dialogTexts.Add(new DialogData("Why so solemn, though? You act like you're walking to school."));

            dialogTexts.Add(new DialogData("It's a beautiful day! Why not pause for a bit and pick a few of these lovely flowers?"));

            flowerPatch.SetActive(true);

            DialogManager.Show(dialogTexts);
        }
    }

}
