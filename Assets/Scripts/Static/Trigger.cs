using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Trigger : MonoBehaviour
{

    public Beginning beg;

    public delegate void  bad();
    public static bad badEnding;

    public delegate void normal();
    public static normal normEnd;

    public delegate void good();
    public static good goodEnd;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.tag == "goodTrigger")
            {
                //Raises flag count
                staticStuff.goodFlags += Convert.ToInt32(!staticStuff.runSoured);
                staticStuff.badFlags += Convert.ToInt32(staticStuff.runSoured);

                //If game is over
                if (staticStuff.goodFlags + staticStuff.badFlags == 8)
                {
                    switch (staticStuff.goodFlags)
                    {
                        case 3:
                            Debug.Log("Bad Ending");
                            badEnding.Invoke();
                            break;
                        case 8:
                            Debug.Log("Good Ending");
                            goodEnd.Invoke();
                            break;
                        default:
                            Debug.Log("Normal");
                            normEnd.Invoke();
                            break;
                    }
                    staticStuff.goodFlags = 0;
                    staticStuff.badFlags = 0;
                }

                switch (staticStuff.badFlags + staticStuff.goodFlags)
                {
                    case 1:
                        beg.ResetController("Here again, my darling, is your grandmother still not well? Take to her this basket, with a loaf of bread and wine, and let her eat and drink and gain her strength again. " +
                        "Take care and do not stray off the path, lest mischief follow.");
                        break;
                    case 2:                    
                        beg.ResetController("Here again, my darling, is your grandmother still not well? Take to her this basket, with a loaf of bread and wine, and let her eat and drink and gain her strength again. " +
                        "Take care and do not stray off the path, lest mischief follow.");
                        break;
                    case 3:
                        if (staticStuff.runSoured)
                        {
                            beg.ResetController("I've heard tales of wolves in the woods darling... stay on the path.");
                        }
                        else
                        {
                            beg.ResetController("Here again, my darling, is your grandmother still not well? Take to her this basket, with a loaf of bread and wine, and let her eat and drink and gain her strength again. " +
                            "Take care and do not stray off the path, lest mischief follow.");
                        }
                        break;
                    case 4:
                        if (staticStuff.runSoured)
                        {
                            beg.ResetController("You smell a bit odd today, my darling...stay on the path. Be good to your mother.");
                        }
                        else
                        {
                            beg.ResetController("Here again, my darling, is your grandmother still not well? Take to her this basket, with a loaf of bread and wine, and let her eat and drink and gain her strength again. " +
                            "Take care and do not stray off the path, lest mischief follow.");
                        }
                        break;
                    case 5:
                        if (staticStuff.runSoured)
                        {
                            beg.ResetController("Seems you're lacking a toe, my darling. Surely you didn't s':tr%^aaaa#}'*^y. Oh well, grandmother must have her basket. We'll simply have to replace it. Come here...");
                        }
                        else
                        {
                            beg.ResetController("Here again, my darling, is your grandmother still not well? Take to her this basket, with a loaf of bread and wine, and let her eat and drink and gain her strength again. " +
                            "Take care and do not stray off the path, lest mischief follow.");
                        }
                        break;
                    case 6:
                        if (staticStuff.runSoured)
                        {
                            beg.ResetController("Beauty is in the eye of the beholder, I suppose.");
                        }
                        else
                        {
                            beg.ResetController("Here again, my darling, is your grandmother still not well? Take to her this basket, with a loaf of bread and wine, and let her eat and drink and gain her strength again. " +
                            "Take care and do not stray off the path, lest mischief follow.");
                        }
                        break;
                    case 7:
                        if (staticStuff.runSoured)
                        {
                            beg.ResetController("Blind and foolish child.");
                        }
                        else
                        {
                            beg.ResetController("Here again, my darling, is your grandmother still not well? Take to her this basket, with a loaf of bread and wine, and let her eat and drink and gain her strength again. " +
                            "Take care and do not stray off the path, lest mischief follow.");
                        }
                        break;
                }
                //Resets soured run
                staticStuff.runSoured = false;
            }   
            //Logs the flags
            Debug.Log($"Bad Flags: {staticStuff.badFlags}");
            Debug.Log($"Good Flags: {staticStuff.goodFlags}");
        }
        //Teleports player, plays approprate mom text
        
    }
}
