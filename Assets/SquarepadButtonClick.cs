using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SquarepadButtonClick : MonoBehaviour
{
    public TMP_InputField inputField;
    public Rigidbody doorRigidbody;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public int firstFlag = 0;
    public int secondFlag = 0;
    public int thirdFlag = 0;
    public int fourthFlag = 0;
    public int fifthFlag = 0;
    public int sixthFlag = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int ChangeSquarepadFlag(int flag)
    {
        if (flag == 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public void CheckIfFlagCorrect()
    {
        if (secondFlag == 1 && thirdFlag == 1 && sixthFlag == 1 && firstFlag == 0 && fourthFlag == 0 && fifthFlag == 0)
        {
            doorRigidbody.constraints = RigidbodyConstraints.None;
            inputField.text = "correct answer!";
        }
        else
        {
            inputField.text = "wrong answer..";
        }
    }

    public void SquarepadButtonOneClick()
    {
        Debug.Log(firstFlag);
        audioSource.PlayOneShot(audioClip);
        firstFlag = ChangeSquarepadFlag(firstFlag);
        if (firstFlag == 1)
        {
            button1.image.color = new Color32(0, 5, 255, 255);
        }
        else
        {
            button1.image.color = new Color32(207, 118, 130, 255);
        }
        CheckIfFlagCorrect();
    }

    public void SquarepadButtonTwoClick()
    {
        audioSource.PlayOneShot(audioClip);
        secondFlag = ChangeSquarepadFlag(secondFlag);
        if (secondFlag == 1)
        {
            button2.image.color = new Color32(0, 5, 255, 255);
        }
        else
        {
            button2.image.color = new Color32(207, 118, 130, 255);
        }
        CheckIfFlagCorrect();
    }

    public void SquarepadButtonThreeClick()
    {
        audioSource.PlayOneShot(audioClip);
        thirdFlag = ChangeSquarepadFlag(thirdFlag);
        if (thirdFlag == 1)
        {
            button3.image.color = new Color32(0, 5, 255, 255);
        }
        else
        {
            button3.image.color = new Color32(207, 118, 130, 255);
        }
        CheckIfFlagCorrect();
    }

    public void SquarepadButtonFourClick()
    {
        audioSource.PlayOneShot(audioClip);
        fourthFlag = ChangeSquarepadFlag(fourthFlag);
        if (fourthFlag == 1)
        {
            button4.image.color = new Color32(0, 5, 255, 255);
        }
        else
        {
            button4.image.color = new Color32(207, 118, 130, 255);
        }
        CheckIfFlagCorrect();
    }

    public void SquarepadButtonFiveClick()
    {
        audioSource.PlayOneShot(audioClip);
        fifthFlag = ChangeSquarepadFlag(fifthFlag);
        if (fifthFlag == 1)
        {
            button5.image.color = new Color32(0, 5, 255, 255);
        }
        else
        {
            button5.image.color = new Color32(207, 118, 130, 255);
        }
        CheckIfFlagCorrect();
    }

    public void SquarepadButtonSixClick()
    {
        audioSource.PlayOneShot(audioClip);
        sixthFlag = ChangeSquarepadFlag(sixthFlag);
        if (sixthFlag == 1)
        {
            button6.image.color = new Color32(0, 5, 255, 255);
        }
        else
        {
            button6.image.color = new Color32(207, 118, 130, 255);
        }
        CheckIfFlagCorrect();
    }
}
