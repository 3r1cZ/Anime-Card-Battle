using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip buttonEffect;
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/


    private void Awake()
    {
        DontDestroyOnLoad(src);
        
    }
    // sound for button clicked
    public void Button1() { 
        src.clip = buttonEffect;
        src.Play();
    }
}
