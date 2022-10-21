using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
        //Should the debug file be enabled?
        public bool debugEnabled;

        public int goodFlag;
        public int badFlags;

        public bool normalRun;

        void Start()
        {
            if (debugEnabled)
            {
                staticStuff.goodFlags = goodFlag;
                staticStuff.badFlags = badFlags;
                staticStuff.normal = normalRun;
            }
        }
}
