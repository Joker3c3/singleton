using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }
    public GameObject firstFullHeart;
    public GameObject secondFullHeart;
    public GameObject thirdFullHeart;
    public GameObject vrRig;
    public GameObject diary;
    public GameObject clothes;
    public GameObject potal;
    public Animator firstHeartAnimation;
    public Animator secondHeartAnimation;
    public Animator thirdHeartAnimation;
    public Image firstImage;
    public Image secondImage;
    public Image thirdImage;
    public bool firstDoorOpen = false;
    public bool firstRoomSafeDoorOpen = false;
    public bool LivingRoomSafeDoorOpen = false;
    public bool drawerDoorOpen = false;
    public bool secondDoorOpen = false;
    public bool fireExtinguisherDoorOpen = false;
    public bool isTowelCompleted = false;
    public bool isLifeEnd = false;
    public bool isTowelWet = false;
    public bool isCollisionBodyFire = false;
    public bool isUserStateOverWhelming = false;
    private int life;
    public string userName;
    public string passwordLaptop;
    public string passwordSafe;
    public string passwordSafeLivingRoom;
    public string passwordFireExtinguisher;
    public int passwordLaptopFolder;
    public int rankingScore;
    public int countInFire;
    public int timer;
    public IEnumerator timerCoroutine;
    public float frame;
    public AudioSource audioSourceCamera;
    public AudioClip audioClipAttacked;
    public AudioSource audioSourceGameOver;
    public AudioSource audioSourceGameCompleteEnd;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        SetLife(3);
    }

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void TimerStart()
    {
        StartCoroutine(timerCoroutine);
    }

    public IEnumerator Timer()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(1.0f);
            timer++;
            Debug.Log(timer);
        }
    }

    public void ChangeFlagIsTowelCompleted()
    {
        isTowelCompleted = true;
    }

    public void ChangeFlagIsLifeEnd()
    {
        isLifeEnd = true;
    }

    public void ChangeFlagIsTowelWet()
    {
        isTowelWet = true;
    }

    public void ChangeFlagIsCollisionBodyFire()
    {
        isCollisionBodyFire = true;
    }

    public void ChangeFlagIsUserStateOverWhelming()
    {
        isUserStateOverWhelming = true;
    }

    public void ChangeLife()
    {
        life--;
    }

    public void SetLife(int value)
    {
        life = value;
    }

    public int GetLife()
    {
        return life;
    }

    public void StayUserOverWhelming()
    {
        isUserStateOverWhelming = false;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        GameMangerInstanceReset();
        UiManager.Instance.UiMangerInstanceReset();
        DBManager.Instance.DBManagerInstanceReset();
    }

    public void GameMangerInstanceReset()
    {
        firstFullHeart = GameObject.Find("First Full Heart");
        secondFullHeart = GameObject.Find("Second Full Heart");
        thirdFullHeart = GameObject.Find("Third Full Heart");
        vrRig = GameObject.Find("VR Rig");
        diary = GameObject.Find("Diary");
        clothes = GameObject.Find("clothes");
        potal = GameObject.Find("portal");
        firstHeartAnimation = firstFullHeart.GetComponent<Animator>();
        secondHeartAnimation = secondFullHeart.GetComponent<Animator>();
        thirdHeartAnimation = thirdFullHeart.GetComponent<Animator>();
        firstImage = firstFullHeart.GetComponent<Image>();
        secondImage = secondFullHeart.GetComponent<Image>();
        thirdImage = thirdFullHeart.GetComponent<Image>();
        firstDoorOpen = false;
        firstRoomSafeDoorOpen = false;
        LivingRoomSafeDoorOpen = false;
        drawerDoorOpen = false;
        secondDoorOpen = false;
        fireExtinguisherDoorOpen = false;
        isTowelCompleted = false;
        isLifeEnd = false;
        isTowelWet = false;
        isCollisionBodyFire = false;
        isUserStateOverWhelming = false;

        life = 3;
        userName = "";
        passwordLaptop = "paris";
        passwordSafe = "210305";
        passwordSafeLivingRoom = "●■♣★";
        passwordFireExtinguisher = "FIRE";
        passwordLaptopFolder = 1784358;
        rankingScore = 0;
        countInFire = 3;
        timer = 0;
        timerCoroutine = Timer();
        frame = Time.deltaTime;
        audioSourceCamera = GameObject.Find("VR Rig").transform.GetChild(0).GetChild(0).GetComponent<AudioSource>();
        audioClipAttacked = audioSourceCamera.GetComponent<AudioSource>().clip;
        audioSourceGameOver = vrRig.transform.GetChild(0).GetChild(7).GetComponent<AudioSource>();
        audioSourceGameCompleteEnd = vrRig.transform.GetChild(0).GetChild(8).GetComponent<AudioSource>();

        GameObjectSetActiveFalse(diary.transform.GetChild(1).gameObject);
        GameObjectSetActiveFalse(potal);
        
        audioSourceGameCompleteEnd.mute = true;
        audioSourceGameCompleteEnd.mute = true;
    }

    public void GameObjectSetActiveFalse(GameObject target)
    {
        target.SetActive(false);
    }

    public void GameObjectSetActiveTrue(GameObject target)
    {
        target.SetActive(true);
    }

    public void DamagedByFire()
    {
        Damage();
        ChangeFlagIsCollisionBodyFire();
    }

    private void Damage()
    {
        if (!isUserStateOverWhelming)
        {
            if (life == 1)
            {
                audioSourceCamera.PlayOneShot(audioClipAttacked);
                DamageFirstHeart();
            }
            else if (life == 2)
            {
                audioSourceCamera.PlayOneShot(audioClipAttacked);
                DamageSecondHeart();
            }
            else if (life == 3)
            {
                audioSourceCamera.PlayOneShot(audioClipAttacked);
                DamageThirdHeart();
            }
        }
    }

    private void DamageThirdHeart()
    {
        SetLife(2);
        UiManager.Instance.EnableAnimation(thirdFullHeart, thirdHeartAnimation, thirdImage);
        ChangeFlagIsUserStateOverWhelming();
        isCollisionBodyFire = false;
        Debug.Log("Life = " + GetLife());
        Debug.Log("IsUserOverWhelming = " + isUserStateOverWhelming);
    }

    private void DamageSecondHeart()
    {
        SetLife(1);
        UiManager.Instance.EnableAnimation(secondFullHeart, secondHeartAnimation, secondImage);
        ChangeFlagIsUserStateOverWhelming();
        isCollisionBodyFire = false;
        Debug.Log("Life = " + GetLife());
        Debug.Log("IsUserOverWhelming = " + isUserStateOverWhelming);
    }

    private void DamageFirstHeart()
    {
        SetLife(0);
        UiManager.Instance.EnableAnimation(firstFullHeart, firstHeartAnimation, firstImage);
        ChangeFlagIsUserStateOverWhelming();
        isCollisionBodyFire = false;
        Debug.Log("Life = " + GetLife());
        Debug.Log("IsUserOverWhelming = " + isUserStateOverWhelming);
        HandleGameOver();
    }

    private void HandleGameOver()
    {
        // Game Over
        Debug.Log("Life = " + GetLife());
        Debug.Log("IsUserOverWhelming = " + isUserStateOverWhelming);

        //create reset your game

        Debug.Log("IsCourtinEnd = " + UiManager.Instance.isCorutineEnd);
        StartCoroutine(UiGameEndCoroutine());
        UiManager.Instance.goToMenuButton.GetComponent<Button>().onClick.AddListener(() => WrapperGameOver());

    }

    public void WrapperGameOver()
    {
        audioSourceGameOver.mute = true;
        ReloadScene();
    }

    public void HandleGameEndComplete()
    {
        audioSourceGameCompleteEnd.mute = false;
        UiManager.Instance.UiGameEndComplete();
        DisableMainCamera();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator UiGameEndCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        UiManager.Instance.UiGameEnd();
        audioSourceGameOver.mute = false;
        DisableMainCamera();
    }

    public void DisableMainCamera()
    {
        GameObject camera = GameObject.Find("VR Rig");
        GameObject canvas = GameObject.Find("Life Canvas");
        camera.GetComponent<ContinuousMovement>().enabled = false;
        camera.GetComponent<LocomotionControllerDev>().enabled = false;
        canvas.GetComponent<FollowToTheSide>().enabled = false;
    }

    public void ChangeCameraPosition()
    {
        GameObject roomStartPoint = GameObject.Find("Room Start Point");
        Vector3 position = roomStartPoint.transform.position;
        if(!vrRig)
        {
            vrRig = GameObject.Find("VR Rig");
        }
        else
        {
            vrRig.transform.position = position;
            Debug.Log(position);
            Debug.Log(vrRig.transform.position);
        }
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Game Exit");
    }
}