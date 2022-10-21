using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    //Audio stuff 
    [SerializeField]
    private AudioClip clip;
    [SerializeField]
    private AudioSource auds;
    [SerializeField]
    private int runToPlay;

    //Has the clip been played?
    private bool played;

    //When the trigger is hit, the clip plays and indicates that it was played once
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !played && staticStuff.getRuns() == runToPlay)
        {
            auds.PlayOneShot(clip);
            played = true;
        }
    }
}
