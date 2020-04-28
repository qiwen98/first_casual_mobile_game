using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource myfx;
    
    public static SoundManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

    }

     public void playsound(AudioClip sound)
    {
        myfx.PlayOneShot(sound);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
