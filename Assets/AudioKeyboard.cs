using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioKeyboard : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioKeyboardOnclick()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
