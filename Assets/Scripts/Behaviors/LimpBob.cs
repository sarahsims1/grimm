using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Characters.FirstPerson;

public class LimpBob : MonoBehaviour
{

    [SerializeField]
    private FirstPersonController regBob;

    [SerializeField]
    private FirstPersonController limpBob;

    void Start()
    {
        regBob.enabled = true;
        limpBob.enabled = false;

        stepmomevent.limpStart += StartTheLimp;
        Beginning.stopLimp += StopTheLimp;
    }

    public void StartTheLimp()
    {
        regBob.enabled = false;
        limpBob.enabled = true;
    }

    public void StopTheLimp()
    {
        regBob.enabled = true;
        limpBob.enabled = false;
    }
}
