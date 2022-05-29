using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Transform effectNozzle;
    public GameObject fireExtinguisherEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SquirtFireExtinguisher()
    {
        GameObject spawnedfireExtinguisherEffect = Instantiate(fireExtinguisherEffect, effectNozzle.position, effectNozzle.rotation);
        // audioSource.PlayOneShot(audioClip);
        Destroy(spawnedfireExtinguisherEffect, 2);
    }
}
