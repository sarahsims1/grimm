using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AnimationTrigger : MonoBehaviour
{
    public string[] boolString;

    public Animator[] anime;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<FirstPersonController>().enabled = false;
            other.transform.DetachChildren();
            for (int i = 0; i < anime.Length; i++)
            {
                anime[i].enabled = true;
                anime[i].SetBool(boolString[i], true);
            }        
        }
    }
}
