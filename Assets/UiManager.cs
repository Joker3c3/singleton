using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private static UiManager instance;
    public static UiManager Instance { get => instance; }
    public bool isFirstAttachTowel = false;
    public bool isCollisionTowelWashstand = false;
    public bool isCollisionTowelBody = false;


    
    private void Awake()
    {
        if (instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
    public void ChangeFlagIsFirstAttachTowel()
    {
        this.isFirstAttachTowel = true;
    }

    public void ChangeFlagIsCollisionTowelWashstand()
    {
        this.isCollisionTowelWashstand = true;
    }

    public void changeFlagIsCollisionTowelBody()
    {
        this.isCollisionTowelBody = true;
    }

    public void UiSetActiveTrue(GameObject canvas)
    {
        canvas.SetActive(true);
    }

    public void OnClickUiSetActiveFalse()
    {
        this.isFirstAttachTowel = false;
    }

    public void EnableAnimation(GameObject canvasContents, Animator heartAnimation, Image image)
    {
        if(GameManager.Instance.isLifeChanged)
        {
            heartAnimation.enabled = true;
            Invoke("DisabledAnimation(heartAnimation)", 3f);
            image.enabled = false;            
        }
        if(IsInvoking("DisabledAnimation(heartAnimation"))
        {
            CancelInvoke("DisabledAnimation(heartAnimation)");
        }
    }
    public void DisabledAnimation(Animator animator)
    {
        animator.enabled = false;
    }
}
