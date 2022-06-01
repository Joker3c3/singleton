using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAudio : MonoBehaviour
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

    public void UiAudioOnClick()
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void UiAudioOnClickString(string s)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
