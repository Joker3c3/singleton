using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SecondDoorAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioDoorOpen;
    public AudioClip audioDoorLocked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AudioSecondDoorSelectEntered(SelectEnterEventArgs args)
    {
        if(GameManager.Instance.secondDoorOpen)
        {
            audioSource.PlayOneShot(audioDoorOpen);
        }
        else
        {
            audioSource.PlayOneShot(audioDoorLocked);
        }
    }
}
