using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class mouseSensitivity : MonoBehaviour
{
    public delegate void SensChange();
    public static SensChange sensChange;
    public void AdjustSensitiivty(float newsens)
    {
        MouseLook.XSensitivity = newsens;
        MouseLook.YSensitivity = newsens;
        // sensChange.Invoke();
    }
}
