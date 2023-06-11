using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioMixer _audio;
    public Slider musicSlider;

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("vol", 0.75f);
    }
    public void setVolume(float vol) {
        _audio.SetFloat("vol", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("vol", vol);
    }
}
