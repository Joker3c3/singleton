using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioCabinetDoor : MonoBehaviour
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

    public void AudioCabinetDoorSelectEnter(SelectEnterEventArgs args)
    {
        if(args.interactable.gameObject.name == "Cabinet Door")
        {
            audioSource.PlayOneShot(audioDoorOpen);
        }
    }

}
