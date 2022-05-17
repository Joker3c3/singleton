using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {

        Debug.Log(col.gameObject.name);
        if(col.gameObject.name == "Key")
        {
            // Destroy(this.gameObject);
            // Destroy(col.gameObject);
            GetComponent<Rigidbody>().AddForce(transform.forward * 1500);
        }
    }
}
