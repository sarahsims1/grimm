using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Characters.FirstPerson;

public class LimpBob : MonoBehaviour
{
    public static bool stepmomActive;
    private int counter;

    [SerializeField]
    private FirstPersonController regBob;

    [SerializeField]
    private FirstPersonController limpBob;

    void Start()
    {
        regBob.enabled = true;
        limpBob.enabled = false;
<<<<<<< Updated upstream

        stepmomevent.limpStart += StartTheLimp;
        Beginning.stopLimp += StopTheLimp;
=======
   
        Trigger.stopLimp += StopTheLimp;
>>>>>>> Stashed changes
    }

    private void Update()
    {
        if(stepmomActive && counter == 0)
        {
            stepmomevent.limpStart += StartTheLimp;
            counter = 1;
        }
        else if(!stepmomActive && counter == 1)
        {
            stepmomevent.limpStart -= StartTheLimp;
            counter = 0;
        }
    }
    public void StartTheLimp()
    {
        if (regBob != null && limpBob != null)
        {
            regBob.enabled = false;
            limpBob.enabled = true;
        }
    }

    public void StopTheLimp()
    {
        if (regBob != null && limpBob != null)
        {
            regBob.enabled = true;
            limpBob.enabled = false;
        }
    }
}
