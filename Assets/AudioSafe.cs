using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioSafe : MonoBehaviour
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

    public void AudioSafeSelectEnter(SelectEnterEventArgs args)
    {
        if (args.interactable.gameObject.name == "Safe Door First Room")
        {
            if (GameManager.Instance.firstRoomSafeDoorOpen)
            {
                audioSource.PlayOneShot(audioDoorOpen);
            }
            else
            {
                audioSource.PlayOneShot(audioDoorLock);
            }
        }
    }
}
