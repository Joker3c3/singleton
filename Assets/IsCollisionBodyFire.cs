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
            if (other.tag == "fire" || other.tag == "last_fire")
            {
                Debug.Log("this is " + other.tag);
                GameManager.Instance.DamagedByFire();
            }
            else if (other.tag == "potal")
            {
                GameManager.Instance.ChangeCameraPosition();
                UiManager.Instance.UiSetActiveTrue(UiManager.Instance.lifeCanvas);
                UiManager.Instance.UiSetActiveFalse(UiManager.Instance.lifeCanvas.transform.GetChild(1).gameObject);
                StartCoroutine("Timer");
                audioSource.PlayOneShot(audioPotalEnter);
                startBGM.mute = true;

            }
            else if (other.tag == "exit")
            {
                StopCoroutine("Timer");
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
    public IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1.0f);
            GameManager.Instance.timer++;
            Debug.Log(GameManager.Instance.timer);
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if(other != null)
        {
            if(other.CompareTag("smoke"))
            {
                GameManager.Instance.frame = GameManager.Instance.frame + Time.deltaTime;
                if(GameManager.Instance.frame > 1.0f)
                {
                    GameManager.Instance.DamagedByFire();
                    GameManager.Instance.frame = Time.deltaTime;
                }
            }
        }
        else
        {
           Debug.Log("Collider parameter missing"); 
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("smoke"))
        {
            GameManager.Instance.frame = Time.deltaTime;
        }
    }
}
