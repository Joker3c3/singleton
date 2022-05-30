using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioFireExtinguisherDoor : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioDoorOpen;
    public AudioClip audioDoorLock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioFireExtinguisherDoorSelectEnter(SelectEnterEventArgs args)
    {
        if(GameManager.Instance.fireExtinguisherDoorOpen)
        {
            audioSource.PlayOneShot(audioDoorOpen);
        }
        else
        {
            audioSource.PlayOneShot(audioDoorLock);
        }
    }
}
