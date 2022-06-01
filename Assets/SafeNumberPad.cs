using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SafeNumberPad : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioPasswordCorrect;
    public AudioClip audioPasswordWrong;
    public TextMeshProUGUI placeHolder;
    public TMP_InputField inputField;
    public GameObject safeDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonOneClick()
    {
        inputField.text += "1";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonTwoClick()
    {
        inputField.text += "2";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonThreeClick()
    {
        inputField.text += "3";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonFourClick()
    {
        inputField.text += "4";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonFiveClick()
    {
        inputField.text += "5";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonSixClick()
    {
        inputField.text += "6";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonSevenClick()
    {
        inputField.text += "7";
        audioSource.PlayOneShot(audioClip);
    }
    public void ButtonEightClick()
    {
        inputField.text += "8";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonNineClick()
    {
        inputField.text += "9";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonZeroClick()
    {
        inputField.text += "0";
        audioSource.PlayOneShot(audioClip);
    }

    public void ButtonEnterClick()
    {
        audioSource.PlayOneShot(audioClip);
        if (inputField.text.Length > 0)
        {
            if (inputField.text == GameManager.Instance.passwordSafe)
            {
                safeDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GameManager.Instance.firstRoomSafeDoorOpen = true;
                placeHolder.text = "암호가 일치합니다!";
                inputField.text = "";
                audioSource.PlayOneShot(audioPasswordCorrect);
            }
            else
            {
                placeHolder.text = "잘못된 암호입니다.";
                inputField.text = "";
                audioSource.PlayOneShot(audioPasswordWrong);
            }
        }
        else
        {
            placeHolder.text = "한 자 이상 입력";
            audioSource.PlayOneShot(audioPasswordWrong);
        }
    }

    public void ButtonBackspaceClick()
    {
        audioSource.PlayOneShot(audioClip);
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Remove(inputField.text.Length - 1);
        }
        else
        {
        
        }
    }
}
