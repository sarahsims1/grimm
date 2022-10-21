using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadafterclip : MonoBehaviour
{
    public Animator anime;

    private int counter;
    void Update()
    {
        if(anime.GetCurrentAnimatorClipInfo(0)[0].clip.name == "finalbadend" && counter == 0)
        {
            counter++;
            StartCoroutine(wait());
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("goodEnding");
    }
}
