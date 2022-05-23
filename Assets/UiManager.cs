using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    private static UiManager instance;
    public static UiManager Instance { get => instance; }
    public bool isFirstAttachTowel = false;
    public bool isCollisionTowelWashstand = false;
    public bool isCollisionTowelBody = false;
    public bool isCorutineEnd = false;

    public GameObject goToMenuButton;
    public GameObject endText;

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

    void Start()
    {
        
    }
   
    public void ChangeFlagIsFirstAttachTowel()
    {
        this.isFirstAttachTowel = true;
    }

    public void ChangeFlagIsCollisionTowelWashstand()
    {
        this.isCollisionTowelWashstand = true;
    }

    public void ChangeFlagIsCollisionTowelBody()
    {
        this.isCollisionTowelBody = true;
    }

    public void ChangeFlagIsCourtineEnd()
    {
        this.isCorutineEnd = true;
    }

    public void UiSetActiveTrue(GameObject canvas)
    {
        canvas.SetActive(true);
    }

    public void UiSetActiveFalse(GameObject canvas)
    {
        canvas.SetActive(false);
    }

    public void OnClickUiSetActiveFalse()
    {
        this.isFirstAttachTowel = false;
    }
    
    public void UiMangerInstanceReset()
    {
        isFirstAttachTowel = false;
        isCollisionTowelWashstand = false;
        isCollisionTowelBody = false;
        isCorutineEnd = false;
        goToMenuButton = GameObject.Find("Go To Menu Button");
        endText = GameObject.Find("End Text");
    }

    public void EnableAnimation(GameObject canvasContents, Animator heartAnimation, Image image)
    {
        isCorutineEnd = false;
        heartAnimation.enabled = true;
        StartCoroutine(DisabledAnimation(heartAnimation));
        StartCoroutine(DisabledImage(image));
        StartCoroutine(CourtineEndChangeFlagIsCourtineEnd());
    }

    public IEnumerator DisabledAnimation(Animator animator)
    {
        yield return new WaitForSeconds(5.0f);
        animator.enabled = false;
        GameManager.Instance.StayUserOverWhelming();
        yield break;
    }

    public IEnumerator DisabledImage(Image image)
    {
        yield return new WaitForSeconds(5.0f);
        image.enabled = false;
        yield break;
    }

    public IEnumerator CourtineEndChangeFlagIsCourtineEnd()
    {
        yield return new WaitForSeconds(5.0f);
        ChangeFlagIsCourtineEnd();
        Debug.Log("isCourtinEnd = " + isCorutineEnd);
        yield break;
    }

    public void UiGameEnd()
    {
        goToMenuButton = GameObject.Find("Go To Menu Button");
        GameObject text = GameObject.Find("Text (TMP)");
        endText = GameObject.Find("End Text");
        Debug.Log(goToMenuButton);

        Image image = goToMenuButton.GetComponent<Image>();
        Button button = goToMenuButton.GetComponent<Button>();
        TextMeshProUGUI textMesh = text.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI endTextMesh = endText.GetComponent<TextMeshProUGUI>();

        image.enabled = true;
        button.enabled = true;
        textMesh.enabled = true;
        endTextMesh.enabled = true;

    }



}
