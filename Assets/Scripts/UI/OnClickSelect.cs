using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickSelect : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        ClickEvent.click += Select;
    }

    private void Select()
    {
        button.Select();
    }
}
