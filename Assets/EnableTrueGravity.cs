using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EnableTrueGravity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void EnableTrueGravityWhenGrab()
    {
        GameManager.Instance.clothes.transform.GetChild(3).GetComponent<Rigidbody>().useGravity = true;
    }

    public void SelectEnableTrueGravityWhenGrab(SelectEnterEventArgs args)
    {
        EnableTrueGravityWhenGrab();
    }
}
