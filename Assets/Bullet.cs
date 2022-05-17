using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1000.0f;
    
    void start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }
}
