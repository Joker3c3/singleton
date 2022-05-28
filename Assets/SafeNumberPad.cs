using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SafeNumberPad : MonoBehaviour
{
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
    }

    public void ButtonTwoClick()
    {
        inputField.text += "2";
    }

    public void ButtonThreeClick()
    {
        inputField.text += "3";
    }

    public void ButtonFourClick()
    {
        inputField.text += "4";
    }

    public void ButtonFiveClick()
    {
        inputField.text += "5";
    }

    public void ButtonSixClick()
    {
        inputField.text += "6";
    }

    public void ButtonSevenClick()
    {
        inputField.text += "7";
    }
    public void ButtonEightClick()
    {
        inputField.text += "8";
    }

    public void ButtonNineClick()
    {
        inputField.text += "9";
    }

    public void ButtonZeroClick()
    {
        inputField.text += "0";
    }

    public void ButtonEnterClick()
    {
        if(inputField.text.Length > 0)
        {
            if(inputField.text == "0000")//GameManager.Instance.passwordSafe)
            {
                safeDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                placeHolder.text = "Correct Password.. Door Opened";
                inputField.text = "";
            }
            else
            {
                placeHolder.text = "wrong password";
                inputField.text = "";
            }
        }
        else
        {
            placeHolder.text = "Enter Password at least One";
        }
    }

    public void ButtonBackspaceClick()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Remove(inputField.text.Length - 1);
        }
        else
        {
        
        }
    }
}
