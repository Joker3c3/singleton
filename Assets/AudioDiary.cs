using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioDiary : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioBookOpen;
    public AudioClip audioBookClose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioDiaryOpen(SelectEnterEventArgs args)
    {
        audioSource.PlayOneShot(audioBookOpen);
    }

    public void AudioDiaryClose(SelectEnterEventArgs args)
    {
        audioSource.PlayOneShot(audioBookClose);
    }
}
