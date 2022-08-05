using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    private void Start()
    {
        SoundOn();
    }
    public void SoundOff()
    {
        PlayerPrefs.SetInt("soundState", 0);
    }
    public void SoundOn()
    {
        PlayerPrefs.SetInt("soundState", 1);
    }
}
