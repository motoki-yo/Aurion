using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeScript : MonoBehaviour
{
    private void Awake()
     {
         //Set screen size for Standalone
        #if UNITY_STANDALONE
                Screen.SetResolution(720, 1280, false);
                Screen.fullScreen = false;
        #endif
     }
}
