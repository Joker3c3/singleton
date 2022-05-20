using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWetTowelAttachCamera : MonoBehaviour
{
    public GameObject canvas;
    public bool flag = false;

    void Start()
    {
        if(!canvas)
        {
            canvas = GameObject.Find("Towel Canvas2");
        }
        Debug.Log(canvas);
        canvas.SetActive(false);
        Debug.Log(UiManager.Instance.isCollisionTowelWashstand);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            if(other.tag == "washstand")
            {
                GameManager.Instance.changeFlagIsTowelWet();
                UiManager.Instance.ChangeFlagIsCollisionTowelWashstand();
                if(UiManager.Instance.isCollisionTowelWashstand && !flag)
                {
                    UiManager.Instance.UiSetActiveTrue(canvas);
                    flag = true;                  
                }
                Debug.Log("change flag is towel wet changed");
                Debug.Log(GameManager.Instance.isTowelWet);
            }
            else
            {
                Debug.Log("Is not standwash..");
            }

            if(other.tag == "body" && GameManager.Instance.isTowelWet == true)
            {
                GameManager.Instance.ChangeFlagIsTowelCompleted();
                Debug.Log("Wet Towel is Completed");
            }
            else
            {
                Debug.Log("Is not wet Towel or not attach to body");
            }
        }
        else
        {
            Debug.Log("Collider parameter missing");
        }
 
    }
}
