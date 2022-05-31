using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IsCollisionBodyFire : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioPotalEnter;
    public AudioSource startBGM;

    public void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            Debug.Log(other.name);
            if (other.tag == "fire" || other.tag == "smoke")
            {
                GameManager.Instance.isGameEnd = true;
                Debug.Log("this is " + other.tag);
                GameManager.Instance.DamagedByFire();
            }
            else if (other.tag == "potal")
            {
                GameManager.Instance.ChangeCameraPosition();
                UiManager.Instance.UiSetActiveTrue(UiManager.Instance.lifeCanvas);
                UiManager.Instance.UiSetActiveFalse(UiManager.Instance.lifeCanvas.transform.GetChild(1).gameObject);
                GameManager.Instance.TimerStart();
                audioSource.PlayOneShot(audioPotalEnter);
                startBGM.mute = true;

            }
            else if (other.tag == "exit")
            {
                GameManager.Instance.isGameEnd = true;
                GameManager.Instance.HandleGameEndComplete();
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
