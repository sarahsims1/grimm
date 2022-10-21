using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Doublsb.Dialog;

public class StepMomTalk : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    private int counter;

    private void Awake()
    {
        Talk.talking += ShowYourself;
    }
    private void ShowYourself()
    {
        staticStuff.runSoured = true;

        var dialogTexts = new List<DialogData>();

        var Text1 = new DialogData("Hello, child. Why don't you come over here for a second?");

        Text1.SelectList.Add("Polite", "Alright...");

        Text1.SelectList.Add("Mean", "I'm not supposed to go with strangers.");

        Text1.Callback = () => Check_Response();
        Talk.selectActive = true;

        dialogTexts.Add(Text1);

        DialogManager.Show(dialogTexts);
    }

    private void Update()
    {
        if (DialogManager._current_Data.PrintText.Equals("On") && counter == 0)
        {
            stepmomevent.Begin();
            counter++;
        }
    }
    private void Check_Response()
    {

        Talk.selectActive = false;

        if (DialogManager.Result == "Polite")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("Why don't you try on his slipper? If it fits, you'll be the bride to the prince..."));

            dialogTexts.Add(new DialogData("/speed:up/... /speed:down/ ./speed:up/.."));

            dialogTexts.Add(new DialogData("Oh... seems it doesn't quite fit. Your foot is too big? Ha ha. It thought for sure you'd be small enough... /wait:1/  well, never mind. "));

            dialogTexts.Add(new DialogData("We'll make it work..."));

            dialogTexts.Add(new DialogData("One way or another."));

            DialogManager.Show(dialogTexts);

        }

        else if (DialogManager.Result == "Mean")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("Is that so? Well, I can't help but point out that YOU came up to ME, dear."));

            dialogTexts.Add(new DialogData("But, no matter. Why don't you try on his slipper? If it fits, you'll be the bride to the prince..."));

            dialogTexts.Add(new DialogData("/speed:up/... /speed:down/ ./speed:up/.."));

            dialogTexts.Add(new DialogData("Oh... seems it doesn't quite fit. Your foot is too big? Ha ha. It thought for sure you'd be small enough... /wait:1/  well, never mind. "));

            dialogTexts.Add(new DialogData("We'll make it work..."));

            dialogTexts.Add(new DialogData("One way or another."));

            DialogManager.Show(dialogTexts);
        }
    }
  
    
}
