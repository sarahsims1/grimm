using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public static class staticStuff 
{
    //bad runs and good runs (decide whether run is good/bad)
    public static int badFlags;
    public static int goodFlags;

    //Bool locks player into the normal route
    public static bool normal;

    //bool to keep track of whether run is good
    public static bool runSoured;


    public static int getRuns()
    {
        return badFlags+goodFlags;
    }
   
}
