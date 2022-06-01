using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SafeLivingRoomButton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioPasswordCorrect;
    public AudioClip audioPasswordWrong;
    public TMP_InputField inputField;
    public GameObject safeDoor;
    public TextMeshProUGUI placeHolder;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonAndClick()
    {
        inputField.text += "&";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonMultiplyClick()
    {
        inputField.text += "*";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonHeartClick()
    {
        inputField.text += "♡";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonCircleClick()
    {
        inputField.text += "●";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonCloverClick()
    {
        inputField.text += "♣";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonAlphaClick()
    {
        inputField.text += "@";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonStarClick()
    {
        inputField.text += "★";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonEqualClick()
    {
        inputField.text += "=";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonBrokenHeartClick()
    {
        inputField.text += "♥";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonSquareClick()
    {
        inputField.text += "■";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonEnterClick()
    {
        audioSource.PlayOneShot(audioClip);
        if (inputField.text.Length > 0)
        {
            if (inputField.text == GameManager.Instance.passwordSafeLivingRoom)
            {
                if(!safeDoor)
                {
                    safeDoor = GameObject.Find("Safe Door Living Room");
                }
                safeDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GameManager.Instance.LivingRoomSafeDoorOpen = true;
                placeHolder.text = "암호가 일치합니다!";
                inputField.text = "";
                audioSource.PlayOneShot(audioPasswordCorrect);
            }
            else
            {
                audioSource.PlayOneShot(audioPasswordWrong);
                placeHolder.text = "잘못된 암호입니다.";
                inputField.text = "";
            }
        }
        else
        {
            audioSource.PlayOneShot(audioPasswordWrong);
            placeHolder.text = "한 자 이상 입력";
        }
    }

    public void ButtonBackspaceClick()
    {
        audioSource.PlayOneShot(audioClip);
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Remove(inputField.text.Length - 1);
        }

    }




}
