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

    private void OnDisable()
    {
        Talk.talking -= ShowYourself;
    }
    private void ShowYourself()
    {
        staticStuff.runSoured = true;

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Hello, child. Why don't you come here for a second? I have an offer that might interest you..."));

        dialogTexts.Add(new DialogData("See this slipper? The prince of this land wants to marry the girl that it fits. It's rather small, though."));

        dialogTexts.Add(new DialogData("Here's the deal: if the slipper fits, I'll give it to you. Then, when you are Queen, you let me live it the palace."));

        dialogTexts.Add(new DialogData("That's fair, isn't it? What do you think?"));

        var Text1 = new DialogData("(Try on the slipper?)");

        Text1.SelectList.Add("Polite", "Sounds fair to me.");

        Text1.SelectList.Add("Mean", "This doesn't feel right...");

        Text1.Callback = () => Check_Response();
        Talk.selectActive = true;

        dialogTexts.Add(Text1);
        if (DialogManager != null)
        {
            DialogManager.Show(dialogTexts);
        }
    }

    private void Update()
    {
        if (DialogManager != null)
        {
            if (DialogManager._current_Data.PrintText.Equals("On") && counter == 0)
            {
                stepmomevent.Begin();
                counter++;
            }
        }
    }
    private void Check_Response()
    {

        Talk.selectActive = false;

        if (DialogManager.Result == "Polite")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("I thought you looked clever. Alright, try it on!"));

            dialogTexts.Add(new DialogData("/speed:up/... /speed:down/ ./speed:up/.."));

            dialogTexts.Add(new DialogData("Oh... seems it doesn't quite fit. Your toe is too big. Ha ha. It thought for sure you'd be small enough/speed:down/... /speed:up/well, never mind."));

            dialogTexts.Add(new DialogData("We'll make it fit..."));

            dialogTexts.Add(new DialogData("One way or another."));

            DialogManager.Show(dialogTexts);

        }

        else if (DialogManager.Result == "Mean")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("Oh. Well, I suppose you're not so clever after all. I'll just have to find someone else."));

            DialogManager.Show(dialogTexts);
        }
    }
  
    
}
