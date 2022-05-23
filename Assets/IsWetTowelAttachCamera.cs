using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWetTowelAttachCamera : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvasBody;
    public bool flag1 = false;
    public bool flag2 = false;

    void Start()
    {
        if(!canvas)
        {
            canvas = GameObject.Find("Towel Canvas2");
        }
        if(!canvasBody)
        {
            canvasBody = GameObject.Find("Towel Canvas3");
        }
        Debug.Log(canvas);
        canvas.SetActive(false);
        canvasBody.SetActive(false);
        Debug.Log(UiManager.Instance.isCollisionTowelWashstand);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            if(other.tag == "washstand")
            {
                GameManager.Instance.ChangeFlagIsTowelWet();
                UiManager.Instance.ChangeFlagIsCollisionTowelWashstand();
                if(UiManager.Instance.isCollisionTowelWashstand && !flag1)
                {
                    UiManager.Instance.UiSetActiveTrue(canvas);
                    flag1 = true;                  
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
                UiManager.Instance.ChangeFlagIsCollisionTowelBody();
                if(UiManager.Instance.isCollisionTowelBody && !flag2)
                {
                    UiManager.Instance.UiSetActiveTrue(canvasBody);
                    flag2 = true;
                }
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
