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

    public FirstPersonController fps;
    public AudioClip fs2;
    public AudioClip fs3;

    public delegate void LimpCont();
    public static LimpCont stopLimp;
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
                            EndingManager.whichEnding = 3;
                            Debug.Log("Bad Ending");
                            badEnding.Invoke();
                            if (staticStuff.endHasBeenGot) staticStuff.twoEndsHaveBeenGot = true;
                            staticStuff.endHasBeenGot = true;                        
                            break;
                        case 8:
                            Debug.Log("Good Ending");
                            EndingManager.whichEnding = 1;
                            goodEnd.Invoke();
                            if (staticStuff.endHasBeenGot) staticStuff.twoEndsHaveBeenGot = true;
                            staticStuff.endHasBeenGot = true;
                            break;
                        default:
                            EndingManager.whichEnding = 2;
                            Debug.Log("Normal");
                            normEnd.Invoke();
                            if (staticStuff.endHasBeenGot) staticStuff.twoEndsHaveBeenGot = true;
                            staticStuff.endHasBeenGot = true;
                            break;
                    }
                }

                switch (staticStuff.badFlags + staticStuff.goodFlags)
                {
                    case 1:
                        beg.ResetController("Darling, your grandmother is still sick. Be a dear and visit her agian, will you?");
                        break;
                    case 2:                    
                        beg.ResetController("It seems your poor granny is still not well. It's good that you're checking on her every day, she might not be well for a while now.");
                        break;
                    case 3:
                        if (staticStuff.runSoured)
                        {
                            beg.ResetController("I've heard tales of wolves in the woods darling... stay on the path.");
                        }
                        else
                        {
                            beg.ResetController("Here's this morning's basket, dear. Send your grandma my love.");
                        }
                        break;
                    case 4:
                        if (staticStuff.runSoured)
                        {
                            beg.ResetController("You smell a bit odd today, my darling...stay on the path. Be good to your mother.");
                        }
                        else
                        {
                            beg.ResetController("You're doing so well to visit your grandma every day. Be sure to stay on the path!");
                        }
                        break;
                    case 5:
                        if (staticStuff.runSoured)
                        {
                            stopLimp();
                            beg.ResetController("Seems you're lacking a toe, my darling. Surely you didn't s':tr%^aaaa#}'*^y. Oh well, grandmother must have her basket.");
                            fps.m_FootstepSounds[1] = fs2;
                            fps.m_FootstepSounds[2] = fs3;
                        }
                        else
                        {
                            beg.ResetController("Hurry straight there and back today, love.");
                        }
                        break;
                    case 6:
                        if (staticStuff.runSoured)
                        {
                            beg.ResetController("Beauty is in the eye of the beholder, I suppose.");
                        }
                        else
                        {
                            beg.ResetController("Your granny is growing stronger every day. Hopefully she'll be better soon.");
                        }
                        break;
                    case 7:
                        if (staticStuff.runSoured)
                        {
                            stopLimp();
                            beg.ResetController("Blind and foolish child.");
                        }
                        else
                        {
                            beg.ResetController("Send your grandmother my love today, darling. This is going to be the last time you see her for a while.");
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
