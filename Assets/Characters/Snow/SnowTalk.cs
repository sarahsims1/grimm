using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class SnowTalk : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    private void Awake()
    {
        Talk.talking += ShowYourself;
    }
    private void OnDisable()
    {
        Talk.talking -= ShowYourself;
    }
    private void Update()
    {
        if (DialogManager._current_Data.PrintText.Equals("Do"))
        {
            snowevent.Begin();
        }
    }
    private void ShowYourself()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Hello.", "Wolf"));

        dialogTexts.Add(new DialogData("Could you help me? I'm a little lost...", "Wolf"));

        dialogTexts.Add(new DialogData("My stepmother tried to kill me, because I'm too pretty...", "Wolf"));

        dialogTexts.Add(new DialogData("/speed:down/...", "Wolf"));

        var Text1 = new DialogData("Do you think I'm pretty?", "Wolf");

        Talk.selectActive = true;

        dialogTexts.Add(Text1);

        DialogManager.Show(dialogTexts);
    }

}
