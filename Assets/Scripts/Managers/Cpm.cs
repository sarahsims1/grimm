using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cpm : MonoBehaviour
{
    //Arrays for objects to be activated/deactivated in each run

    [Header("Objects for Each Run")]

    [Header("Objects to be activated")]
    public GameObject[] zeroAct;
    public GameObject[] oneAct;
    public GameObject[] twoAct;
    public GameObject[] threeAct;
    public GameObject[] fourAct;
    public GameObject[] fiveAct;
    public GameObject[] sixAct;
    public GameObject[] sevenAct;

    [Header("Objects to be deactivated")]
    public GameObject[] zeroDeact;
    public GameObject[] oneDeact;
    public GameObject[] twoDeact;
    public GameObject[] threeDeact;
    public GameObject[] fourDeact;
    public GameObject[] fiveDeact;
    public GameObject[] sixDeact;
    public GameObject[] sevenDeact;

    void Update()
    {
        switch (staticStuff.getRuns())
        {
            case 0:
                foreach (GameObject act in zeroAct)
                {
                    act.SetActive(true);
                    MonoBehaviour[] c = act.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = true;
                    }
                }
                foreach (GameObject deact in zeroDeact)
                {
                    deact.SetActive(false);
                    MonoBehaviour[] c = deact.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = false;
                    }
                }
                break;
            case 1:
                foreach (GameObject act in oneAct)
                {
                    act.SetActive(true);
                    MonoBehaviour[] c = act.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = true;
                    }
                }
                foreach (GameObject deact in oneDeact)
                {
                    deact.SetActive(false);
                    MonoBehaviour[] c = deact.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = false;
                    }
                }
                break;
            case 2:
                foreach (GameObject act in twoAct)
                {
                    act.SetActive(true);
                    MonoBehaviour[] c = act.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = true;
                    }
                }
                foreach (GameObject deact in twoDeact)
                {
                    deact.SetActive(false);
                    MonoBehaviour[] c = deact.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = false;
                    }
                }
                break;
            case 3:
                foreach (GameObject act in threeAct)
                {
                    act.SetActive(true);
                    MonoBehaviour[] c = act.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = true;
                    }
                }
                foreach (GameObject deact in threeDeact)
                {
                    deact.SetActive(false);
                    MonoBehaviour[] c = deact.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = false;
                    }
                }
                break;
            case 4:
                foreach (GameObject act in fourAct)
                {
                    act.SetActive(true);
                    MonoBehaviour[] c = act.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = true;
                    }
                }
                foreach (GameObject deact in fourDeact)
                {
                    deact.SetActive(false);
                    MonoBehaviour[] c = deact.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = false;
                    }
                }
                break;
            case 5:
                foreach (GameObject act in fiveAct)
                {
                    act.SetActive(true);
                    MonoBehaviour[] c = act.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = true;
                    }
                }
                foreach (GameObject deact in fiveDeact)
                {
                    deact.SetActive(false);
                    MonoBehaviour[] c = deact.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = false;
                    }
                }
                break;
            case 6:
                foreach (GameObject act in sixAct)
                {
                    act.SetActive(true);
                    MonoBehaviour[] c = act.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = true;
                    }
                }
                foreach (GameObject deact in sixDeact)
                {
                    deact.SetActive(false);
                    MonoBehaviour[] c = deact.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = false;
                    }
                }
                break;
            case 7:
                foreach (GameObject act in sevenAct)
                {
                    act.SetActive(true);
                    MonoBehaviour[] c = act.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = true;
                    }
                }
                foreach (GameObject deact in sevenDeact)
                {
                    deact.SetActive(false);
                    MonoBehaviour[] c = deact.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour comp in c)
                    {
                        comp.enabled = false;
                    }
                }
                break;
        }
    }
}
