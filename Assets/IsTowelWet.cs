using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTowelWet : MonoBehaviour
{
    public GameObject canvas;
    public void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            if(other.tag == "washstand")
            {
                GameManager.Instance.changeFlagIsTowelWet();
                Debug.Log("change flag is towel wet changed");
            }
            else
            {
                Debug.Log("Is not standwash..");
            }
        }
        else
        {
            Debug.Log("Collider parameter missing");
        }
 
    }
}
