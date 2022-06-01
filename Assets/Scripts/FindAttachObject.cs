using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FindAttachObject : MonoBehaviour
{
    public XRSocketInteractor snapZone;
    public GameObject findObject;

    // Start is called before the first frame update
    void Start()
    {
        // findObject = GameObject.Find("Beretta (1)");
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AttachSnapZoneObject(SelectEnterEventArgs args)
    {
        if (snapZone.isActiveAndEnabled)
        {
            // Debug.Log(snapZone.GetOldestInteractableHovered().transform.gameObject.name);
            if (args != null)
            {
                if (findObject.name == args.interactable.gameObject.name)
                {
                    GameManager.Instance.ChangeFlagIsTowelCompleted();
                    Debug.Log("We get Towel! ");
                    Debug.Log(GameManager.Instance.isTowelCompleted);
                }
                
            }
            else
            {
                Debug.Log("There is no event args parameter");
            }
        }
        else
        {
            Debug.Log("Snap Zone not founded");
        }
    }

}
