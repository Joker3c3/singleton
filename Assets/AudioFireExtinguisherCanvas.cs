using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFireExtinguisherCanvas : MonoBehaviour
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

    public void AudioFireExtinguisherCanvasOnClick()
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void AudioFireExtinguisherCanvasOnClickString(string s)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
