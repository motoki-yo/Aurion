using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TempoSplash : MonoBehaviour
{
    // Start is called before the first frame update
    public float targetTime = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan timespan = TimeSpan.FromSeconds(targetTime);
        targetTime -= Time.deltaTime;
        if (targetTime <= 0)
        {
            Application.LoadLevel("UserInterface");
        }
    }
}
