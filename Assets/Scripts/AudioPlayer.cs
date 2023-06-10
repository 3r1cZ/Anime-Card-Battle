using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource sfx;
    public AudioSource backgroundMusic;
    public AudioClip buttonEffect;
    public AudioClip background;
    // Start is called before the first frame update
    void Start()
    {
        if (backgroundMusic != null) {
            backgroundMusic.clip = background;

            backgroundMusic.Play();
        }
  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Awake()
    {
        if (sfx != null)
        {
            DontDestroyOnLoad(sfx);
        }
        if (backgroundMusic != null) {
            DontDestroyOnLoad(backgroundMusic);
        }
        
    }
    // sound for button clicked
    public void ButtonMakeSound() { 
        sfx.clip = buttonEffect;
        sfx.Play();
    }
}
