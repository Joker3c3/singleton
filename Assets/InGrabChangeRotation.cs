using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InGrabChangeRotation : MonoBehaviour
{
    public GameObject target;
    public GameObject doorHandle;

    
    void FixedUpdate()
    {
        GameManager.Instance.doorPosition = doorHandle.transform.rotation;
        Debug.Log(GameManager.Instance.doorPosition);
    }

    public void InGrabChangeRotationTarget(SelectEnterEventArgs args)
    {
        if (args.interactable.gameObject.name == target.name)
        {
            // Debug.Log(target.name);
            // Debug.Log(target.transform.GetChild(0).GetChild(0).GetChild(1));
            target.transform.GetChild(0).GetChild(0).GetChild(1).rotation = Quaternion.Euler(GameManager.Instance.doorPosition.x, GameManager.Instance.doorPosition.y, GameManager.Instance.doorPosition.z-40);
            target.transform.GetChild(0).GetChild(0).GetChild(2).GetChild(1).rotation = Quaternion.Euler(GameManager.Instance.doorPosition.x, GameManager.Instance.doorPosition.y, GameManager.Instance.doorPosition.z-40);
        }
    }

    public void InGrabChangeRotationTargetExit(SelectExitEventArgs args)
    {
        if (args.interactable.gameObject.name == target.name)
        {
            Debug.Log(target.name);
            Debug.Log(target.transform.GetChild(0).GetChild(0).GetChild(2).GetChild(1));
            Debug.Log(GameManager.Instance.doorPosition);
            target.transform.GetChild(0).GetChild(0).GetChild(1).rotation = Quaternion.Euler(GameManager.Instance.doorPosition.x, GameManager.Instance.doorPosition.y, GameManager.Instance.doorPosition.z);
            target.transform.GetChild(0).GetChild(0).GetChild(2).GetChild(1).rotation = Quaternion.Euler(GameManager.Instance.doorPosition.x, GameManager.Instance.doorPosition.y, GameManager.Instance.doorPosition.z);
        }
    }
}
