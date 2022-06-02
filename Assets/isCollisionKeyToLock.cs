using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class isCollisionKeyToLock : MonoBehaviour
{
    public Rigidbody doorRigidbody;
    public AudioSource audioSource;
    public AudioClip audioClip;
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
        if(other.tag == "first_room_lock")
        {
            audioSource.PlayOneShot(audioClip);
            GameManager.Instance.firstDoorOpen = true;
            doorRigidbody.constraints = RigidbodyConstraints.None;
            if (!UiManager.Instance.isKeyAttachHandleFirst)
            {
                UiManager.Instance.smokeWarningCanvas.SetActive(true);
                UiManager.Instance.isKeyAttachHandleFirst = true;
            }
            GameManager.Instance.teleportationLivingRoomFloor.GetComponent<TeleportationArea>().enabled = true;
            GameManager.Instance.teleportationToiletFloor.GetComponent<TeleportationArea>().enabled = true;
        }
    }
}
