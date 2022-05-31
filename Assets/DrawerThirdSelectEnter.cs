using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrawerThirdSelectEnter : MonoBehaviour
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

    public void DrawerThirdGrabSelectEnter(SelectEnterEventArgs args)
    {
        if(args.interactable.gameObject.name == "drawer2")
        {
            audioSource.PlayOneShot(audioDoorOpen);
        }
    }
}
