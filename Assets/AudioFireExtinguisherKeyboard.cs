using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFireExtinguisherKeyboard : MonoBehaviour
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

    public void AudioFireExtinguisherKeyboardOnClick()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
