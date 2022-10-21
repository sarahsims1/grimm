using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class badnormEndings : MonoBehaviour
{
    //When an ending is triggerd, sets the bool on the object spawn script and takes the player to the end of the game.
    void Start()
    {
        Trigger.badEnding += BadEnding;
        Trigger.normEnd += NormalEnding;
        Trigger.goodEnd += GoodEnding;
    }

    void BadEnding()
    {
        endingObjectSpawn.badEnd = true;
        SceneManager.LoadScene("grannyhouse");
    }

    void NormalEnding()
    {
        endingObjectSpawn.badEnd = false;
        SceneManager.LoadScene("grannyhouse");
    }

    void GoodEnding()
    {
        SceneManager.LoadScene("goodEnding");
    }
}
