using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightScript : MonoBehaviour
{
    public float rotationsPerMinute;

    public static bool Paused
    {
        get;
        set;
    }

    void Start()
    {
        Paused = false;
    }

    void Update()
    {
        if (!Paused)
        {
            transform.Rotate(0, 6.0f * rotationsPerMinute * Time.deltaTime, 0);
        }
    }
}