using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowelCollisionTrigger : MonoBehaviour
{
    public GameObject towel;
    public BoxCollider collide;
    // Start is called before the first frame update
    void Start()
    {
        towel = GameObject.Find("Beige Towel");
        collide = towel.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
