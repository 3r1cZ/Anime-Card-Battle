using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioMixer _audio;

    public void setVolume(float vol) {
        _audio.SetFloat("vol", vol);
    }
}
