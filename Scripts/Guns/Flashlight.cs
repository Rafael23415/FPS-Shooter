using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    bool on;
    public AudioSource turnOn;
    public Light flashlight;

    void Start()
    {
        on = false;
        flashlight.enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L) && Time.deltaTime != 0f)
        {
            if (on)
            {
                turnOn.Play();
                on = false;
                flashlight.enabled = false;
            }
            else if (!on)
            {
                turnOn.Play();
                on = true;
                flashlight.enabled = true;
            }
        }  
    }
}
