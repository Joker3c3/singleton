using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FindAttachObjectTowel : MonoBehaviour
{
    public XRDirectInteractor leftHand;
    public XRDirectInteractor rightHand;
    public GameObject findObject;
    public GameObject canvas;
    public bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        findObject = GameObject.Find("Beige Towel");
        canvas = GameObject.Find("Towel Canvas 1");
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FindAttachGrabObject(SelectEnterEventArgs args)
    {
        if (leftHand.isActiveAndEnabled || rightHand.isActiveAndEnabled)
        {
            if (args != null)
            {
                if (findObject.name == args.interactable.gameObject.name)
                {
                    UiManager.Instance.ChangeFlagIsFirstAttachTowel();
                    if(UiManager.Instance.isFirstAttachTowel && !flag)
                    {
                        UiManager.Instance.UiSetActiveTrue(canvas);
                        flag = true;
                    }
                    Debug.Log("We get Towel! ");
                    Debug.Log(UiManager.Instance.isFirstAttachTowel);
                }

            }
            else
            {
                Debug.Log("There is no event args parameter");
            }
        }
        else
        {
            Debug.Log("hand grab missing");
        }
    }

}
