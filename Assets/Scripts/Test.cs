using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ingzol(TeleportingEventArgs args)
    {
        Debug.Log(args.teleportRequest.destinationPosition.x);
        Debug.Log(args.teleportRequest.destinationPosition.y);
        Debug.Log(args.teleportRequest.destinationPosition.z);
    }
}
