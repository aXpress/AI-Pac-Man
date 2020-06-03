using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPrefs : MonoBehaviour {
    private static readonly string soundPref = "soundPref";
    private float soundFloat;
    public AudioSource[] soundEffectFiles;

    void Awake () {
        loadAudioPrefs();
	}
	
	private void loadAudioPrefs() {

        soundFloat = PlayerPrefs.GetFloat(soundPref);

        for (int i = 0; i < soundEffectFiles.Length; i++)
        {
            soundEffectFiles[i].volume = soundFloat;
        }
    }
}
