using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IsDoorAttach : MonoBehaviour
{
    public GameObject door;
    public GameObject unvisibleWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter =" + other.tag);
        Debug.Log(door.GetComponent<XRGrabInteractable>().gameObject.name);
        if (other.tag == "door")
        {
            unvisibleWall.SetActive(true);
            door.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            unvisibleWall.SetActive(true);
            door.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "door")
        {
            door.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            unvisibleWall.SetActive(true);
            if (door.GetComponent<XRGrabInteractable>().gameObject.name == door.name)
            {
                unvisibleWall.SetActive(false);
                door.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
            else
            {
                unvisibleWall.SetActive(true);
                door.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
        else
        {
            unvisibleWall.SetActive(true);
            door.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit =" + other.tag);
        Debug.Log(door.GetComponent<XRGrabInteractable>().gameObject.name);
        if (other.tag == "door")
        {
            door.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            unvisibleWall.SetActive(false);
        }
        else
        {
            unvisibleWall.SetActive(true);
            door.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
