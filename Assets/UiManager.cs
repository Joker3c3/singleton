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
        goToMenuButton = GameObject.Find("Go To Menu Button");
        endText = GameObject.Find("End Text");
        lifeCanvas = GameObject.Find("Life Canvas");
        startMapCanvas = GameObject.Find("Start Map Canvas");
        gameDescriptionCanvas = GameObject.Find("Game Description Canvas");
        rankingBoardCanvas = GameObject.Find("Ranking Board Canvas");
        audioSettingCanvas = GameObject.Find("Audio Setting Canvas");
        userNameCanvas = GameObject.Find("User Name Canvas");
        rankingBoardPrefab = GameObject.Find("ranking_board_panel_prefab");
        rankingBoardParent = rankingBoardCanvas.transform.GetChild(0).gameObject;
        keyBoard = GameObject.Find("Keyboard");
        inputUserName = userNameCanvas.transform.GetChild(0).GetChild(1).GetComponent<TMP_InputField>();
        safeCanvas = GameObject.Find("Safe Canvas");
        safeInputField = safeCanvas.transform.GetChild(0).GetChild(0).GetComponent<TMP_InputField>();
        laptopKeyBoard = GameObject.Find("Laptop Keyboard");
        laptopCanvas = GameObject.Find("Laptop Canvas");
        diaryCanvas = GameObject.Find("Diary Canvas");
        fireExtinguisherCanvas = GameObject.Find("FireExtinguisherCanvas");
        fireExtinguisherInputField = fireExtinguisherCanvas.transform.GetChild(0).GetChild(1).GetComponent<TMP_InputField>();
        fireExtinguisherDoor = GameObject.Find("Fire Extinguisher Door");
        
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
            
            //for laptopUi
            Button firstEnter = laptopKeyBoard.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(4).GetChild(3).GetComponent<Button>();
            firstEnter.onClick.AddListener(()=>TriggerFirstEnter());
            Button folderButtonGirlfriend = laptopCanvas.transform.GetChild(1).GetChild(0).GetComponent<Button>();
            folderButtonGirlfriend.onClick.AddListener(()=>UiLaptopCanvasFolderButtonGirlfriendPush());
            Button thirdEnter = laptopKeyBoard.transform.GetChild(2).GetChild(1).GetChild(1).GetChild(4).GetChild(3).GetComponent<Button>();
            thirdEnter.onClick.AddListener(()=>TriggerThirdEnter());
            
            //at third, return second
            Button thirdUndoButton = laptopCanvas.transform.GetChild(2).GetChild(2).GetComponent<Button>();
            thirdUndoButton.onClick.AddListener(()=>UiLaptopCanvasUndoButtonPush());

            //at fourth
            Button fourthEnter = laptopCanvas.transform.GetChild(3).GetChild(0).GetComponent<Button>();
            fourthEnter.onClick.AddListener(()=>TriggerFourthEnter());
            //at fourth return
            Button fourthUndoButton = laptopCanvas.transform.GetChild(3).GetChild(2).GetComponent<Button>();
            fourthUndoButton.onClick.AddListener(()=>LaptopKeyboardFifthBackspacePush());

            Button fifthUndoButton = laptopCanvas.transform.GetChild(4).GetChild(1).GetComponent<Button>();
            fifthUndoButton.onClick.AddListener(()=>UiLaptopCanvasFifthUndoButtonPush());

            //garbage
            Button folderButtonTrash = laptopCanvas.transform.GetChild(1).GetChild(2).GetComponent<Button>();
            folderButtonTrash.onClick.AddListener(()=>UiLaptopCanvasFolderButtonTrashPush());
            Button folderButtonTrashUndo = laptopCanvas.transform.GetChild(5).GetChild(1).GetComponent<Button>();
            folderButtonTrashUndo.onClick.AddListener(()=>UiLaptopCanvasSixthUndoButtonPush());

            //My PC
            Button folderButtonMyPC = laptopCanvas.transform.GetChild(1).GetChild(4).GetComponent<Button>();
            folderButtonMyPC.onClick.AddListener(() => UiLaptopCanvasFolderButtonMyPcPush());
            Button seventhEnter = laptopKeyBoard.transform.GetChild(6).GetChild(1).GetChild(1).GetChild(4).GetChild(3).GetComponent<Button>();
            seventhEnter.onClick.AddListener(() => TriggerSeventhEnter());

            Button fireExtinguisherKeyboardEnter = fireExtinguisherCanvas.transform.GetChild(1).GetChild(1).GetChild(1).GetChild(4).GetChild(3).GetComponent<Button>();
            fireExtinguisherKeyboardEnter.onClick.AddListener(() => CheckCorrectPasswordFireExtinguisher());
            Button fireExtinguisherCanvasContinueButton = fireExtinguisherCanvas.transform.GetChild(2).GetChild(1).GetComponent<Button>();
            fireExtinguisherCanvasContinueButton.onClick.AddListener(() => FireExtinguisherCanvasContinueButtonPush());
            Button fireExtinguisherCanvasReturnButton = fireExtinguisherCanvas.transform.GetChild(3).GetChild(1).GetComponent<Button>();
            fireExtinguisherCanvasReturnButton.onClick.AddListener(() => fireExtinguisherCanvasReturnButtonPush());

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

    public void TriggerFirstEnter()
    {
        Debug.Log(laptopCanvas.transform.GetChild(0).GetChild(0).GetComponent<TMP_InputField>().text);
        Debug.Log(GameManager.Instance.passwordLaptop);
        if(laptopCanvas.transform.GetChild(0).GetChild(0).GetComponent<TMP_InputField>().text == GameManager.Instance.passwordLaptop)
        {
            UiSetActiveFalse(laptopCanvas.transform.GetChild(0).gameObject);
            UiSetActiveTrue(laptopCanvas.transform.GetChild(1).gameObject);
            UiSetActiveFalse(laptopKeyBoard.transform.GetChild(0).gameObject);
            UiSetActiveTrue(laptopKeyBoard.transform.GetChild(1).gameObject);
        }
        else
        {
            laptopCanvas.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = "wrong password";
        }
    }

    public void UiLaptopCanvasFolderButtonGirlfriendPush()
    {
        UiSetActiveFalse(laptopCanvas.transform.GetChild(1).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(2).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(1).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(2).gameObject);
    }

    public void TriggerThirdEnter()
    {
        if(laptopCanvas.transform.GetChild(2).GetChild(0).GetComponent<TMP_InputField>().text == GameManager.Instance.passwordLaptopFolder.ToString())
        {
            UiSetActiveFalse(laptopCanvas.transform.GetChild(2).gameObject);
            UiSetActiveTrue(laptopCanvas.transform.GetChild(3).gameObject);
            UiSetActiveFalse(laptopKeyBoard.transform.GetChild(2).gameObject);
            UiSetActiveTrue(laptopKeyBoard.transform.GetChild(3).gameObject);
        }
        else
        {
            laptopCanvas.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "wrong password";
        }
    }

    public void UiLaptopCanvasUndoButtonPush()
    {
        UiSetActiveFalse(laptopCanvas.transform.GetChild(2).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(1).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(2).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(1).gameObject);
    }

    public void TriggerFourthEnter()
    {
        UiSetActiveFalse(laptopCanvas.transform.GetChild(3).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(4).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(3).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(4).gameObject);
    }

    public void LaptopKeyboardFifthBackspacePush()
    {
        UiSetActiveFalse(laptopCanvas.transform.GetChild(3).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(1).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(3).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(1).gameObject);
    }

    public void UiLaptopCanvasFifthUndoButtonPush()
    {
        UiSetActiveFalse(laptopCanvas.transform.GetChild(4).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(3).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(4).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(3).gameObject);
    }

    public void UiLaptopCanvasFolderButtonTrashPush()
    {
        UiSetActiveFalse(laptopCanvas.transform.GetChild(1).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(5).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(1).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(5).gameObject);
    }

    public void UiLaptopCanvasSixthUndoButtonPush()
    {
        UiSetActiveFalse(laptopCanvas.transform.GetChild(5).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(1).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(5).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(1).gameObject);
    }

    public void UiLaptopCanvasFolderButtonMyPcPush()
    {
        UiSetActiveFalse(laptopCanvas.transform.GetChild(1).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(6).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(1).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(6).gameObject);
    }

    public void TriggerSeventhEnter()
    {
        UiSetActiveFalse(laptopCanvas.transform.GetChild(6).gameObject);
        UiSetActiveTrue(laptopCanvas.transform.GetChild(1).gameObject);
        UiSetActiveFalse(laptopKeyBoard.transform.GetChild(6).gameObject);
        UiSetActiveTrue(laptopKeyBoard.transform.GetChild(1).gameObject);
    }

    public void UiFireExtinguisherCanvas()
    {
        UiSetActiveTrue(fireExtinguisherCanvas.gameObject);
        UiSetActiveFalse(fireExtinguisherCanvas.transform.GetChild(1).gameObject);
        UiSetActiveFalse(fireExtinguisherCanvas.transform.GetChild(2).gameObject);
        UiSetActiveFalse(fireExtinguisherCanvas.transform.GetChild(3).gameObject);
    }

    public void CheckCorrectPasswordFireExtinguisher()
    {
        if(fireExtinguisherInputField.text == GameManager.Instance.passwordFireExtinguisher)
        {
            UiSetActiveFalse(fireExtinguisherCanvas.transform.GetChild(0).gameObject);
            UiSetActiveTrue(fireExtinguisherCanvas.transform.GetChild(2).gameObject);
            fireExtinguisherDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameManager.Instance.fireExtinguisherDoorOpen = true;
        }
        else
        {
            UiSetActiveFalse(fireExtinguisherCanvas.transform.GetChild(0).gameObject);
            UiSetActiveTrue(fireExtinguisherCanvas.transform.GetChild(3).gameObject);
        }
    }

    public void FireExtinguisherCanvasContinueButtonPush()
    {
        UiSetActiveFalse(fireExtinguisherCanvas.gameObject);
    }

    public void fireExtinguisherCanvasReturnButtonPush()
    {
        UiSetActiveFalse(fireExtinguisherCanvas.transform.GetChild(3).gameObject);
        UiSetActiveTrue(fireExtinguisherCanvas.transform.GetChild(0).gameObject);
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
