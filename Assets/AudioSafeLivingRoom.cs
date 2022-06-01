using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioSafeLivingRoom : MonoBehaviour
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

    public void AudioSafeLivingRoomSelectEnter(SelectEnterEventArgs args)
    {
        if(args.interactable.gameObject.name == "Safe Door Living Room")
        {
            if(GameManager.Instance.LivingRoomSafeDoorOpen)
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
