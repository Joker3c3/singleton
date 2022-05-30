using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThirdDoorAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioDoorOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThirdDoorAudioSelectEnter(SelectEnterEventArgs args)
    {
        audioSource.PlayOneShot(audioDoorOpen);
    }
}
