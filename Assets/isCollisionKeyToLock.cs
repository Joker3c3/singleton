using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isCollisionKeyToLock : MonoBehaviour
{
    public Rigidbody doorRigidbody;
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
            doorRigidbody.constraints = RigidbodyConstraints.None;
        }
    }
}
