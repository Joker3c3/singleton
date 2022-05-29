using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCollisionLivingRoomKeyLock : MonoBehaviour
{
    public GameObject livingRoomLock;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Rigidbody doorRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider ohter)
    {
        if(ohter.tag == "living_room_lock")
        {
            doorRigidbody.constraints = RigidbodyConstraints.None;
            livingRoomLock.tag = "Untagged";
            audioSource.PlayOneShot(audioClip);
        }
    }
}
