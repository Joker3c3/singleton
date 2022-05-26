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
    public GameObject lifeCanvas;
    public GameObject startMapCanvas;
    public GameObject gameDescriptionCanvas;
    public GameObject rankingBoardCanvas;
    public GameObject audioSettingCanvas;
    public GameObject userNameCanvas;
    public GameObject rankingBoardPrefab;
    public GameObject rankingBoardParent;
    public GameObject keyBoard;
    public TMP_InputField inputUserName;


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
        if(!lifeCanvas)
        {
            lifeCanvas = GameObject.Find("Life Canvas");
            Debug.Log(lifeCanvas);
            UiSetActiveFalse(lifeCanvas);
        }
        else 
        {
            UiSetActiveFalse(lifeCanvas);
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
        
        if(!lifeCanvas)
        {
            lifeCanvas = GameObject.Find("Life Canvas");
            Debug.Log(lifeCanvas);
            UiSetActiveFalse(lifeCanvas);
        }
        else 
        {
            UiSetActiveFalse(lifeCanvas);
        }
        UiSetActiveFalse(gameDescriptionCanvas);
        UiSetActiveFalse(rankingBoardCanvas);
        UiSetActiveFalse(audioSettingCanvas);
        UiSetActiveFalse(startMapCanvas);
        UiSetActiveFalse(keyBoard);
        UiGameStart();
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

    public void UiGameStart()
    {
        if(!startMapCanvas)
        {
            startMapCanvas = GameObject.Find("Start Map Canvas");
        }
        else
        {
            Button gameStartButton = startMapCanvas.transform.GetChild(0).GetChild(1).GetComponent<Button>();
            gameStartButton.onClick.AddListener(() => UiGameStartButtonPush());
            Button gameDescriptionReturnButton = gameDescriptionCanvas.transform.GetChild(0).GetChild(1).GetComponent<Button>();
            gameDescriptionReturnButton.onClick.AddListener(() => UiGameDescriptionReturnButtonPush());
            Button rankingBoardButton = startMapCanvas.transform.GetChild(0).GetChild(2).GetComponent<Button>();
            rankingBoardButton.onClick.AddListener(() => UiRainkingButtonPush());
            Button rankingBoardReturnButton = rankingBoardCanvas.transform.GetChild(0).GetChild(1).GetComponent<Button>();
            rankingBoardReturnButton.onClick.AddListener(() => UiRankingBoardReturnButtonPush());
            Button gameAudioButton = startMapCanvas.transform.GetChild(0).GetChild(3).GetComponent<Button>();
            gameAudioButton.onClick.AddListener(() => UiGameAudioButtonPush());
            Button audioSettingReturnButton = audioSettingCanvas.transform.GetChild(0).GetChild(5).GetComponent<Button>();
            audioSettingReturnButton.onClick.AddListener(() => UiAudioSettingReturnButtonPush());
            Button userNameInputEndButton = userNameCanvas.transform.GetChild(0).GetChild(3).GetComponent<Button>();
            userNameInputEndButton.onClick.AddListener(()=> UiUserNameInputEndButtonPush());
            Button userNameInputExitButton = userNameCanvas.transform.GetChild(0).GetChild(4).GetComponent<Button>();
            userNameInputExitButton.onClick.AddListener(()=>UiUserNameInputExitButtonPush());
            Button gameExitButton = startMapCanvas.transform.GetChild(0).GetChild(4).GetComponent<Button>();
            gameExitButton.onClick.AddListener(()=>GameExitButtonPush());
            // startMapCanvas.GetComponent<Button>().onClick.AddListener(() => ReloadScene());
        }
    }

    public void UiGameStartButtonPush()
    {
        if(!startMapCanvas)
        {
            startMapCanvas = GameObject.Find("Start Map Canvas");
        }
        else
        {
            UiSetActiveFalse(startMapCanvas);
            if(!gameDescriptionCanvas)
            {
                gameDescriptionCanvas = GameObject.Find("Game Description Canvas");
                UiSetActiveTrue(gameDescriptionCanvas);
            }
            else
            {
                UiSetActiveTrue(gameDescriptionCanvas);
            }
        }
       
    }

    public void UiGameDescriptionReturnButtonPush()
    {
        UiSetActiveFalse(gameDescriptionCanvas);
        UiSetActiveTrue(startMapCanvas);
    }

    public void UiRainkingButtonPush()
    {
        UiSetActiveFalse(startMapCanvas);
        UiSetActiveTrue(rankingBoardCanvas);
        RankingBoardRender render = new RankingBoardRender(rankingBoardPrefab, rankingBoardParent);
        render.RenderRankingBoard();
    }

    public void UiRankingBoardReturnButtonPush()
    {
        UiSetActiveFalse(rankingBoardCanvas);
        UiSetActiveTrue(startMapCanvas);
    }

    public void UiGameAudioButtonPush()
    {
        UiSetActiveFalse(startMapCanvas);
        UiSetActiveTrue(audioSettingCanvas);
    }

    public void UiAudioSettingReturnButtonPush()
    {
        UiSetActiveFalse(audioSettingCanvas);
        UiSetActiveTrue(startMapCanvas);
    }

    public void UiUserNameInputEndButtonPush()
    {
        Debug.Log(inputUserName.text);
        if(inputUserName.text.Length > 0)
        {
            Debug.Log(inputUserName.text);
            UiSetActiveFalse(userNameCanvas);
            UiSetActiveTrue(startMapCanvas);

            GameManager.Instance.userName = inputUserName.text;
        }
        else
        {
            inputUserName.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = "한 자 이상 입력해주세요.";
        }
    }

    public void UiUserNameInputExitButtonPush()
    {
        Application.Quit();
    }

    public void GameExitButtonPush()
    {
        Application.Quit();
    }

    public void OnApplicationQuit()
    {

    }


}
