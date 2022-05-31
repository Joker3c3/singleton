using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrawerSelectEnter : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioDrawerOpen;
    public AudioClip audioDrawerLock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawerGrabSelectEnter(SelectEnterEventArgs args)
    {
        if(args.interactable.gameObject.name == "drawer3")
        {
            if(GameManager.Instance.drawerDoorOpen)
            {
                audioSource.PlayOneShot(audioDrawerOpen);
            }
            else
            {
                audioSource.PlayOneShot(audioDrawerLock);
            }
        }
    }
}
