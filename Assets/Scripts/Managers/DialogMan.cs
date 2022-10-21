using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogMan : MonoBehaviour
{
    //Event that indicates the dialogue is finished
    public delegate void DialogDone();
    public static event DialogDone DialogFin;
}
