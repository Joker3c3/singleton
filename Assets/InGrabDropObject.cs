using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InGrabDropObject : MonoBehaviour
{
    public GameObject studentIdCard;
    // Start is called before the first frame update
    void Start()
    {
        studentIdCard.gameObject.SetActive(false);
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

        if(args.interactable.gameObject.name == "shirt (3)")
        {
            StartCoroutine(CoroutineStudentIdCard());
        }
    }

    public IEnumerator CoroutineStudentIdCard()
    {
        yield return new WaitForSeconds(0.5f);
        studentIdCard.SetActive(true);
        yield break;
    }
}
