using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SafeLivingRoomButton : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject safeDoor;
    public TextMeshProUGUI placeHolder;
    public string passWordSafeLivingRoom;
    // Start is called before the first frame update
    void Start()
    {
        passWordSafeLivingRoom = "@@@@";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonAndClick()
    {
        inputField.text += "&";
    }

    public void ButtonMultiplyClick()
    {
        inputField.text += "*";
    }

    public void ButtonHeartClick()
    {
        inputField.text += "♡";
    }

    public void ButtonCircleClick()
    {
        inputField.text += "●";
    }

    public void ButtonCloverClick()
    {
        inputField.text += "♣";
    }

    public void ButtonAlphaClick()
    {
        inputField.text += "@";
    }

    public void ButtonStarClick()
    {
        inputField.text += "★";
    }

    public void ButtonEqualClick()
    {
        inputField.text += "=";
    }

    public void ButtonBrokenHeartClick()
    {
        inputField.text += "♥";
    }

    public void ButtonSquareClick()
    {
        inputField.text += "■";
    }

    public void ButtonEnterClick()
    {
        if (inputField.text.Length > 0)
        {
            if (inputField.text == passWordSafeLivingRoom)
            {
                if(!safeDoor)
                {
                    safeDoor = GameObject.Find("Safe Door Living Room");
                }
                safeDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                placeHolder.text = "correct password";
                inputField.text = "";
            }
            else
            {
                placeHolder.text = "Wrong Password";
                inputField.text = "";
            }
        }
        else
        {
            placeHolder.text = "need one word";
        }
    }

    public void ButtonBackspaceClick()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Remove(inputField.text.Length - 1);
        }

    }




}
