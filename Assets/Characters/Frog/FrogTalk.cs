using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class FrogTalk : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    private void Awake()
    {
        TalkFrog.talking += ShowYourself;
    }
    private void ShowYourself()
    {
        staticStuff.runSoured = true;

        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("*Ribbit*", "Frog"));

        dialogTexts.Add(new DialogData("Ah, excuse me.", "Frog"));

        dialogTexts.Add(new DialogData("May I help you?", "Frog"));

        dialogTexts.Add(new DialogData("... Am I a prince? Ho ho - *ribbit* - I'm afraid not. I'm just a simple frog.", "Frog"));

        dialogTexts.Add(new DialogData("You can ask my friends if you like, though.", "Frog"));

        dialogTexts.Add(new DialogData("Here they come now.", "Frog"));

        DialogManager.Show(dialogTexts);
    }

}
