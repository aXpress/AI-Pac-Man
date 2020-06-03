using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioManager : MonoBehaviour {

    private int firstTimeInt;
    private static readonly string firstTime = "firstTime";
    private static readonly string soundPref = "soundPref";
    private float soundFloat;
    public Slider soundSlider;
    public AudioSource[] soundEffectFiles;

	void Start () {
        firstTimeInt = PlayerPrefs.GetInt(firstTime);

        if(firstTimeInt == 0)
        {
            soundFloat = 0.5f;
            soundSlider.value = soundFloat;
            PlayerPrefs.SetFloat(soundPref, soundFloat);
            PlayerPrefs.SetInt(firstTime, -1);
        }
        else
        {
            soundFloat = PlayerPrefs.GetFloat(soundPref);
            soundSlider.value = soundFloat;
        }

	}

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(soundPref, soundSlider.value);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        for(int i = 0; i < soundEffectFiles.Length; i++)
        {
            soundEffectFiles[i].volume = soundSlider.value;
        }
    }

}
