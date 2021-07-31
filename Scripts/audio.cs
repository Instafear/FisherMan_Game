using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioSource splash;
    public AudioSource buttonclick;
    public void spl()
    {
        splash.Play();
    }
    public void click()
    {
        buttonclick.Play();
    }
}
