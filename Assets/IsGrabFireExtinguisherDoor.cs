using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class IsGrabFireExtinguisherDoor : MonoBehaviour
{
    public GameObject fireExtinguisherCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsGrabFireExtinguisherDoorSelectEnter(SelectEnterEventArgs args)
    {
        if(args.interactable.gameObject.name == "Fire Extinguisher Door")
        {
            UiManager.Instance.UiFireExtinguisherCanvas();
        }
    }
}
