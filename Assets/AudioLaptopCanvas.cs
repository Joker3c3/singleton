using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLaptopCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip audioFolderClick;
    public AudioClip audioButtonClick;
    public AudioClip audioWindowBoot;
    public AudioClip audioCorrectPassword;
    public AudioClip audioWrongPassword;
    public AudioClip audioError;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputFieldOnSelect(string s)
    {
        audioSource.PlayOneShot(audioButtonClick);
    }

    public void CorrectPasswordOnClick()
    {
        audioSource.PlayOneShot(audioCorrectPassword);
    }

    public void WrongPasswordOnClick()
    {
        audioSource.PlayOneShot(audioWrongPassword);
    }

    public void FolderOnClick()
    {
        audioSource.PlayOneShot(audioFolderClick);
    }

    public void WindowBootOnClick()
    {
        audioSource.PlayOneShot(audioWindowBoot);
    }

    public void ErrorOnClick()
    {
        audioSource.PlayOneShot(audioError);
    }
}
