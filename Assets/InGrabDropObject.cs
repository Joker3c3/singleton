using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InGrabDropObject : MonoBehaviour
{
    public GameObject studentIdCard;
    public GameObject IdCard;
    // Start is called before the first frame update
    void Start()
    {
        studentIdCard.gameObject.SetActive(false);
        IdCard.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InGrabDropObjectMethod(SelectExitEventArgs args)
    {
        if(!studentIdCard)
        {
            studentIdCard = GameObject.Find("studentTextured");
        }

        if(!IdCard)
        {
            IdCard = GameObject.Find("idTextured");
        }

        if(args.interactable.gameObject.name == "shirt (3)")
        {
            studentIdCard.SetActive(true);
            IdCard.SetActive(true);
        }
    }
}
