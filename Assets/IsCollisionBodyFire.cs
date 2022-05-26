using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IsCollisionBodyFire : MonoBehaviour
{
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
        if (other != null)
        {
            if (other.tag == "fire" || other.tag == "smoke")
            {
                GameManager.Instance.DamagedByFire();
            }
            else if (other.tag == "potal")
            {
                GameManager.Instance.ChangeCameraPosition();
                UiManager.Instance.UiSetActiveTrue(UiManager.Instance.lifeCanvas);
            }
            else
            {
                Debug.Log("Is not fire. You are safe");
            }
        }
        else
        {
            Debug.Log("Collider parameter missing");
        }
    }
}
