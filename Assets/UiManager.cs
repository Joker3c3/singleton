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
    public GameObject laptopCanvas;
    public GameObject rankingBoardPrefab;
    public GameObject rankingBoardParent;
    public GameObject keyBoard;
    public GameObject laptopKeyBoard;
    public GameObject diaryCanvas;
    public GameObject safeCanvas;
    public GameObject fireExtinguisherCanvas;
    public GameObject fireExtinguisherDoor;

    public TMP_InputField inputUserName;
    public TMP_InputField fireExtinguisherInputField;
    public TMP_InputField safeInputField;
    public TextMeshProUGUI gameCompleteEndLifeCanvasInputField;

    public AudioSource fireExtinguisherCanvasAudioSource;
    public AudioSource laptopAudioSource;
    public AudioClip audioFireExtinguisherPasswordCorrect;
    public AudioClip audioFireExtinguisherPasswordWrong;
    public AudioClip audioError;
    public AudioClip audioWindowBoot;

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
        lifeCanvas = GameObject.Find("Life Canvas");
        startMapCanvas = GameObject.Find("Start Map Canvas");
        gameDescriptionCanvas = GameObject.Find("Game Description Canvas");
        rankingBoardCanvas = GameObject.Find("Ranking Board Canvas");
        audioSettingCanvas = GameObject.Find("Audio Setting Canvas");
        userNameCanvas = GameObject.Find("User Name Canvas");
        laptopCanvas = GameObject.Find("Laptop Canvas");
        rankingBoardPrefab = GameObject.Find("ranking_board_panel_prefab");
        rankingBoardParent = rankingBoardCanvas.transform.GetChild(0).gameObject;
        keyBoard = GameObject.Find("Keyboard");
        laptopKeyBoard = GameObject.Find("Laptop Keyboard");
        diaryCanvas = GameObject.Find("Diary Canvas");
        inputUserName = userNameCanvas.transform.GetChild(0).GetChild(1).GetComponent<TMP_InputField>();
        safeCanvas = GameObject.Find("Safe Canvas");
        fireExtinguisherCanvas = GameObject.Find("FireExtinguisherCanvas");
        fireExtinguisherDoor = GameObject.Find("Fire Extinguisher Door");
        safeInputField = safeCanvas.transform.GetChild(0).GetChild(0).GetComponent<TMP_InputField>();
        gameCompleteEndLifeCanvasInputField = lifeCanvas.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        fireExtinguisherInputField = fireExtinguisherCanvas.transform.GetChild(0).GetChild(1).GetComponent<TMP_InputField>();
        fireExtinguisherCanvasAudioSource = fireExtinguisherCanvas.GetComponent<AudioSource>();
        audioFireExtinguisherPasswordCorrect = GameObject.Find("Audio Correct Password").GetComponent<AudioSource>().clip;
        audioFireExtinguisherPasswordWrong = GameObject.Find("Audio Wrong Password").GetComponent<AudioSource>().clip;
        audioError = GameObject.Find("Audio Error").GetComponent<AudioSource>().clip;
        audioWindowBoot = GameObject.Find("Audio Window Boot").GetComponent<AudioSource>().clip;

        UiSetActiveFalse(lifeCanvas);        
        UiSetActiveFalse(gameDescriptionCanvas);
        UiSetActiveFalse(rankingBoardCanvas);
        UiSetActiveFalse(audioSettingCanvas);
        UiSetActiveFalse(startMapCanvas);
        UiSetActiveFalse(keyBoard);
        UiSetActiveFalse(diaryCanvas);
        UiSetActiveFalse(fireExtinguisherCanvas);

        //reset laptopCanvas
        for(int i = 1; i<=6; i++)
        {
            UiSetActiveFalse(laptopCanvas.transform.GetChild(i).gameObject);
        }

        //reset laptopKeyboard
        for(int i = 1; i<=6; i++)
        {
            UiSetActiveFalse(laptopKeyBoard.transform.GetChild(i).gameObject);
        }
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
        GameObject text = GameObject.Find("Go To Menu Button Text");
        endText = GameObject.Find("End Text");

        Image image = goToMenuButton.GetComponent<Image>();
        Button button = goToMenuButton.GetComponent<Button>();
        TextMeshProUGUI textMesh = text.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI endTextMesh = endText.GetComponent<TextMeshProUGUI>();
        Image panelImage = lifeCanvas.transform.GetChild(0).GetComponent<Image>();

        panelImage.color = new Color32(0, 0, 0, 180);
        image.enabled = true;
        button.enabled = true;
        textMesh.enabled = true;
        endTextMesh.enabled = true;
    }

    public void UiGameStart()
    {
        if (!startMapCanvas)
        {
            startMapCanvas = GameObject.Find("Start Map Canvas");
        }
        else
        {
            Button gameStartButton = startMapCanvas.transform.GetChild(0).GetChild(1).GetComponent<Button>();
            gameStartButton.onClick.AddListener(() => WrapperUiGameStartButtonPush());
            Button gameDescriptionReturnButton = gameDescriptionCanvas.transform.GetChild(0).GetChild(1).GetComponent<Button>();
            gameDescriptionReturnButton.onClick.AddListener(() => WrapperUiGameDescriptionReturnButtonPush());
            Button rankingBoardButton = startMapCanvas.transform.GetChild(0).GetChild(2).GetComponent<Button>();
            rankingBoardButton.onClick.AddListener(() => WrapperUiRainkingButtonPush());
            Button rankingBoardReturnButton = rankingBoardCanvas.transform.GetChild(0).GetChild(1).GetComponent<Button>();
            rankingBoardReturnButton.onClick.AddListener(() => WrapperUiRankingBoardReturnButtonPush());
            Button gameAudioButton = startMapCanvas.transform.GetChild(0).GetChild(3).GetComponent<Button>();
            gameAudioButton.onClick.AddListener(() => WrapperUiGameAudioButtonPush());
            Button audioSettingReturnButton = audioSettingCanvas.transform.GetChild(0).GetChild(5).GetComponent<Button>();
            audioSettingReturnButton.onClick.AddListener(() => WrapperUiAudioSettingReturnButtonPush());
            Button userNameInputEndButton = userNameCanvas.transform.GetChild(0).GetChild(3).GetComponent<Button>();
            userNameInputEndButton.onClick.AddListener(() => WrapperUiUserNameInputEndButtonPush());
            Button userNameInputExitButton = userNameCanvas.transform.GetChild(0).GetChild(4).GetComponent<Button>();
            userNameInputExitButton.onClick.AddListener(() => WrapperUiUserNameInputExitButtonPush());
            Button gameExitButton = startMapCanvas.transform.GetChild(0).GetChild(4).GetComponent<Button>();
            gameExitButton.onClick.AddListener(() => WrapperGameExitButtonPush());

            //for laptopUi
            Button firstEnter = laptopKeyBoard.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(4).GetChild(3).GetComponent<Button>();
            firstEnter.onClick.AddListener(() => WrapperTriggerFirstEnter());
            Button folderButtonGirlfriend = laptopCanvas.transform.GetChild(1).GetChild(0).GetComponent<Button>();
            folderButtonGirlfriend.onClick.AddListener(() => WrapperUiLaptopCanvasFolderButtonGirlfriendPush());
            Button thirdEnter = laptopKeyBoard.transform.GetChild(2).GetChild(1).GetChild(1).GetChild(4).GetChild(3).GetComponent<Button>();
            thirdEnter.onClick.AddListener(() => WrapperTriggerThirdEnter());

            //at third, return second
            Button thirdUndoButton = laptopCanvas.transform.GetChild(2).GetChild(2).GetComponent<Button>();
            thirdUndoButton.onClick.AddListener(() => WrapperUiLaptopCanvasUndoButtonPush());

            //at fourth
            Button fourthEnter = laptopCanvas.transform.GetChild(3).GetChild(0).GetComponent<Button>();
            fourthEnter.onClick.AddListener(() => WrapperTriggerFourthEnter());
            //at fourth return
            Button fourthUndoButton = laptopCanvas.transform.GetChild(3).GetChild(2).GetComponent<Button>();
            fourthUndoButton.onClick.AddListener(() => WrapperLaptopKeyboardFifthBackspacePush());

            Button fifthUndoButton = laptopCanvas.transform.GetChild(4).GetChild(1).GetComponent<Button>();
            fifthUndoButton.onClick.AddListener(() => WrapperUiLaptopCanvasFifthUndoButtonPush());

            //garbage
            Button folderButtonTrash = laptopCanvas.transform.GetChild(1).GetChild(2).GetComponent<Button>();
            folderButtonTrash.onClick.AddListener(() => WrapperUiLaptopCanvasFolderButtonTrashPush());
            Button folderButtonTrashUndo = laptopCanvas.transform.GetChild(5).GetChild(1).GetComponent<Button>();
            folderButtonTrashUndo.onClick.AddListener(() => WrapperUiLaptopCanvasSixthUndoButtonPush());

            //My PC
            Button folderButtonMyPC = laptopCanvas.transform.GetChild(1).GetChild(4).GetComponent<Button>();
            folderButtonMyPC.onClick.AddListener(() => WrapperUiLaptopCanvasFolderButtonMyPcPush());
            Button seventhEnter = laptopKeyBoard.transform.GetChild(6).GetChild(1).GetChild(1).GetChild(4).GetChild(3).GetComponent<Button>();
            seventhEnter.onClick.AddListener(() => WrapperTriggerSeventhEnter());

            Button fireExtinguisherKeyboardEnter = fireExtinguisherCanvas.transform.GetChild(1).GetChild(1).GetChild(1).GetChild(4).GetChild(3).GetComponent<Button>();
            fireExtinguisherKeyboardEnter.onClick.AddListener(() => WrapperCheckCorrectPasswordFireExtinguisher());
            Button fireExtinguisherCanvasContinueButton = fireExtinguisherCanvas.transform.GetChild(2).GetChild(1).GetComponent<Button>();
            fireExtinguisherCanvasContinueButton.onClick.AddListener(() => WrapperFireExtinguisherCanvasContinueButtonPush());
            Button fireExtinguisherCanvasReturnButton = fireExtinguisherCanvas.transform.GetChild(3).GetChild(1).GetComponent<Button>();
            fireExtinguisherCanvasReturnButton.onClick.AddListener(() => WrapperfireExtinguisherCanvasReturnButtonPush());

            //lifeCanvas ended
            Button lifeCanvasEndedButton = lifeCanvas.transform.GetChild(1).GetChild(2).GetComponent<Button>();
            lifeCanvasEndedButton.onClick.AddListener(() => UiGameEndCompleteButtonPush());

        }
    }

    public void WrapperUiGameStartButtonPush()
    {
        StartCoroutine(UiGameStartButtonPush());
    }
    public IEnumerator UiGameStartButtonPush()
    {
        yield return new WaitForSeconds(0.5f);
        if (!startMapCanvas)
        {
            startMapCanvas = GameObject.Find("Start Map Canvas");
        }
        else
        {
            UiSetActiveFalse(startMapCanvas);
            if (!gameDescriptionCanvas)
            {
                gameDescriptionCanvas = GameObject.Find("Game Description Canvas");
                UiSetActiveTrue(gameDescriptionCanvas);
            }
            else
            {
                UiSetActiveTrue(gameDescriptionCanvas);
            }
        }
        yield break;
    }

    public void WrapperUiGameDescriptionReturnButtonPush()
    {
        StartCoroutine(UiGameDescriptionReturnButtonPush());
    }
    public IEnumerator UiGameDescriptionReturnButtonPush()
    {
        yield return new WaitForSeconds(0.5f);
        UiSetActiveFalse(gameDescriptionCanvas);
        UiSetActiveTrue(startMapCanvas);
        yield break;
    }

    public void WrapperUiRainkingButtonPush()
    {
        StartCoroutine(UiRainkingButtonPush());
    }
    public IEnumerator UiRainkingButtonPush()
    {
        yield return new WaitForSeconds(0.5f);
        UiSetActiveFalse(startMapCanvas);
        UiSetActiveTrue(rankingBoardCanvas);
        RankingBoardRender render = new RankingBoardRender(rankingBoardPrefab, rankingBoardParent);
        render.RenderRankingBoard();
        yield break;
    }

    public void WrapperUiRankingBoardReturnButtonPush()
    {
        StartCoroutine(UiRankingBoardReturnButtonPush());
    }
    public IEnumerator UiRankingBoardReturnButtonPush()
    {
        yield return new WaitForSeconds(0.5f);
        UiSetActiveFalse(rankingBoardCanvas);
        UiSetActiveTrue(startMapCanvas);
        yield break;
    }

    public void WrapperUiGameAudioButtonPush()
    {
        StartCoroutine(UiGameAudioButtonPush());
    }
    public IEnumerator UiGameAudioButtonPush()
    {
        yield return new WaitForSeconds(0.5f);
        UiSetActiveFalse(startMapCanvas);
        UiSetActiveTrue(audioSettingCanvas);
        yield break;
    }

    public void WrapperUiAudioSettingReturnButtonPush()
    {
        StartCoroutine(UiAudioSettingReturnButtonPush());
    }
    public IEnumerator UiAudioSettingReturnButtonPush()
    {
        yield return new WaitForSeconds(0.5f);
        UiSetActiveFalse(audioSettingCanvas);
        UiSetActiveTrue(startMapCanvas);
        yield break;
    }


    public void WrapperUiUserNameInputEndButtonPush()
    {
        StartCoroutine(UiUserNameInputEndButtonPush());
    }
    public IEnumerator UiUserNameInputEndButtonPush()
    {
        Debug.Log(inputUserName.text);
        yield return new WaitForSeconds(0.5f);
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
        yield break;
    }

    public void WrapperTriggerFirstEnter()
    {
        StartCoroutine(TriggerFirstEnter());
    }
    public IEnumerator TriggerFirstEnter()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log(laptopCanvas.transform.GetChild(0).GetChild(0).GetComponent<TMP_InputField>().text);
        Debug.Log(GameManager.Instance.passwordLaptop);
        if(laptopCanvas.transform.GetChild(0).GetChild(0).GetComponent<TMP_InputField>().text == GameManager.Instance.passwordLaptop)
        {
            laptopAudioSource.PlayOneShot(audioFireExtinguisherPasswordCorrect);
            UiSetActiveFalse(laptopCanvas.transform.GetChild(0).gameObject);
            UiSetActiveTrue(laptopCanvas.transform.GetChild(1).gameObject);
            UiSetActiveFalse(laptopKeyBoard.transform.GetChild(0).gameObject);
            UiSetActiveTrue(laptopKeyBoard.transform.GetChild(1).gameObject);
            laptopAudioSource.PlayOneShot(audioWindowBoot);
        }
        else
        {
            laptopAudioSource.PlayOneShot(audioFireExtinguisherPasswordWrong);
            laptopCanvas.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = "wrong password";
        }
        yield break;
    }

    public void WrapperUiLaptopCanvasFolderButtonGirlfriendPush()
    {
        StartCoroutine(UiLaptopCanvasFolderButtonGirlfriendPush());
    }
    public IEnumerator UiLaptopCanvasFolderButtonGirlfriendPush()
    {
        yield return new WaitForSeconds(0.5f);
        UiSetActiveFalse(laptopCanvas.transform.GetChild(1).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(2).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(1).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(2).gameObject);
        yield break;
    }

    public void WrapperTriggerThirdEnter()
    {
        StartCoroutine(TriggerThirdEnter());
    }
    public IEnumerator TriggerThirdEnter()
    {
        yield return new WaitForSeconds(0.5f);
        if(laptopCanvas.transform.GetChild(2).GetChild(0).GetComponent<TMP_InputField>().text == GameManager.Instance.passwordLaptopFolder.ToString())
        {
            laptopAudioSource.PlayOneShot(audioFireExtinguisherPasswordCorrect);
            UiSetActiveFalse(laptopCanvas.transform.GetChild(2).gameObject);
            UiSetActiveTrue(laptopCanvas.transform.GetChild(3).gameObject);
            UiSetActiveFalse(laptopKeyBoard.transform.GetChild(2).gameObject);
            UiSetActiveTrue(laptopKeyBoard.transform.GetChild(3).gameObject);
        }
        else
        {
            laptopAudioSource.PlayOneShot(audioFireExtinguisherPasswordWrong);
            laptopCanvas.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "wrong password";
        }
        yield break;
    }

    public void WrapperUiLaptopCanvasUndoButtonPush()
    {
        StartCoroutine(UiLaptopCanvasUndoButtonPush());
    }
    public IEnumerator UiLaptopCanvasUndoButtonPush()
    {
        yield return new WaitForSeconds(0.5f);
        UiSetActiveFalse(laptopCanvas.transform.GetChild(2).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(1).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(2).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(1).gameObject);
        yield break;
    }

    public void WrapperTriggerFourthEnter()
    {
        StartCoroutine(TriggerFourthEnter());
    }
    public IEnumerator TriggerFourthEnter()
    {
        yield return new WaitForSeconds(0.5f);
        UiSetActiveFalse(laptopCanvas.transform.GetChild(3).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(4).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(3).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(4).gameObject);
        yield break;
    }

    public void WrapperLaptopKeyboardFifthBackspacePush()
    {
        StartCoroutine(LaptopKeyboardFifthBackspacePush());
    }
    public IEnumerator LaptopKeyboardFifthBackspacePush()
    {
        yield return new WaitForSeconds(0.5f);
        UiSetActiveFalse(laptopCanvas.transform.GetChild(3).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(1).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(3).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(1).gameObject);
        yield break;
    }

    public void WrapperUiLaptopCanvasFifthUndoButtonPush()
    {
        StartCoroutine(UiLaptopCanvasFifthUndoButtonPush());
    }
    public IEnumerator UiLaptopCanvasFifthUndoButtonPush()
    {
        yield return new WaitForSeconds(0.5f);
        UiSetActiveFalse(laptopCanvas.transform.GetChild(4).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(3).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(4).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(3).gameObject);
        yield break;
    }

    public void WrapperUiLaptopCanvasFolderButtonTrashPush()
    {
        StartCoroutine(UiLaptopCanvasFolderButtonTrashPush());
    }
    public IEnumerator UiLaptopCanvasFolderButtonTrashPush()
    {
        yield return new WaitForSeconds(0.5f);
        UiSetActiveFalse(laptopCanvas.transform.GetChild(1).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(5).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(1).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(5).gameObject);
        yield break;
    }

    public void WrapperUiLaptopCanvasSixthUndoButtonPush()
    {
        StartCoroutine(UiLaptopCanvasSixthUndoButtonPush());
    }
    public IEnumerator UiLaptopCanvasSixthUndoButtonPush()
    {
        yield return new WaitForSeconds(0.5f);
        UiSetActiveFalse(laptopCanvas.transform.GetChild(5).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(1).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(5).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(1).gameObject);
        yield break;
    }

    public void WrapperUiLaptopCanvasFolderButtonMyPcPush()
    {
        StartCoroutine(UiLaptopCanvasFolderButtonMyPcPush());
    }
    public IEnumerator UiLaptopCanvasFolderButtonMyPcPush()
    {
        yield return new WaitForSeconds(0.5f);
        laptopAudioSource.PlayOneShot(audioError);
        UiSetActiveFalse(laptopCanvas.transform.GetChild(1).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(6).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(1).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(6).gameObject);
        yield break;
    }

    public void WrapperTriggerSeventhEnter()
    {
        StartCoroutine(TriggerSeventhEnter());
    }
    public IEnumerator TriggerSeventhEnter()
    {
        yield return new WaitForSeconds(0.5f);
        UiSetActiveFalse(laptopCanvas.transform.GetChild(6).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(1).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(6).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(1).gameObject);
        yield break;
    }

    public void UiFireExtinguisherCanvas()
    {
        UiSetActiveTrue(fireExtinguisherCanvas.gameObject);
        UiSetActiveFalse(fireExtinguisherCanvas.transform.GetChild(1).gameObject);
        UiSetActiveFalse(fireExtinguisherCanvas.transform.GetChild(2).gameObject);
        UiSetActiveFalse(fireExtinguisherCanvas.transform.GetChild(3).gameObject);
    }

    public void WrapperCheckCorrectPasswordFireExtinguisher()
    {
        StartCoroutine(CheckCorrectPasswordFireExtinguisher());
    }
    public IEnumerator CheckCorrectPasswordFireExtinguisher()
    {
        yield return new WaitForSeconds(0.5f);
        if(fireExtinguisherInputField.text == GameManager.Instance.passwordFireExtinguisher)
        {
            fireExtinguisherCanvasAudioSource.PlayOneShot(audioFireExtinguisherPasswordCorrect);
            UiSetActiveFalse(fireExtinguisherCanvas.transform.GetChild(0).gameObject);
            UiSetActiveTrue(fireExtinguisherCanvas.transform.GetChild(2).gameObject);
            fireExtinguisherDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameManager.Instance.fireExtinguisherDoorOpen = true;
        }
        else
        {
            fireExtinguisherCanvasAudioSource.PlayOneShot(audioFireExtinguisherPasswordWrong);
            UiSetActiveFalse(fireExtinguisherCanvas.transform.GetChild(0).gameObject);
            UiSetActiveTrue(fireExtinguisherCanvas.transform.GetChild(3).gameObject);
        }
        yield break;
    }

    public void WrapperFireExtinguisherCanvasContinueButtonPush()
    {
        StartCoroutine(FireExtinguisherCanvasContinueButtonPush());
    }
    public IEnumerator FireExtinguisherCanvasContinueButtonPush()
    {
        yield return new WaitForSeconds(0.5f);
        UiSetActiveFalse(fireExtinguisherCanvas.gameObject);
        yield break;
    }

    public void WrapperfireExtinguisherCanvasReturnButtonPush()
    {
        StartCoroutine(fireExtinguisherCanvasReturnButtonPush());
    }
    public IEnumerator fireExtinguisherCanvasReturnButtonPush()
    {
        yield return new WaitForSeconds(0.5f);
        fireExtinguisherInputField.text = "";
        UiSetActiveFalse(fireExtinguisherCanvas.transform.GetChild(3).gameObject);
        UiSetActiveTrue(fireExtinguisherCanvas.transform.GetChild(0).gameObject);
        yield break;
    }

    public void WrapperUiUserNameInputExitButtonPush()
    {
        StartCoroutine(UiUserNameInputExitButtonPush());
    }
    public IEnumerator UiUserNameInputExitButtonPush()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
        yield break;
    }

    public void WrapperGameExitButtonPush()
    {
        StartCoroutine(GameExitButtonPush());
    }
    public IEnumerator GameExitButtonPush()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
        yield break;
    }

    public void UiGameEndComplete()
    {
        lifeCanvas.transform.GetChild(1).gameObject.SetActive(true);
        gameCompleteEndLifeCanvasInputField.text = GameManager.Instance.timer.ToString() + "초 입니다.";
    }

    public void UiGameEndCompleteButtonPush()
    {
        GameManager.Instance.audioSourceGameCompleteEnd.mute = true;
        DBManager.Instance.SetDatabaseAdd(GameManager.Instance.userName, GameManager.Instance.timer);
        //마지막 랭킹보드 등록 눌렸을 때 DB저장
        DBManager.Instance.JsonSave();
        GameManager.Instance.ReloadScene();
    }

    private void OnApplicationQuit()
    {

    }


}
