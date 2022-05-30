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
    public string passwordFireExtinguisher;
    public int passwordLaptopFolder;
    public int rankingScore;
    public int countInFire;

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

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
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

        
    }

    public void GameMangerInstanceReset()
    {
        isTowelCompleted = false;
        isLifeEnd = false;
        isTowelWet = false;
        isCollisionBodyFire = false;
        isUserStateOverWhelming = false;
        life = 3;
        firstFullHeart = GameObject.Find("First Full Heart");
        secondFullHeart = GameObject.Find("Second Full Heart");
        thirdFullHeart = GameObject.Find("Third Full Heart");
        firstHeartAnimation = firstFullHeart.GetComponent<Animator>();
        secondHeartAnimation = secondFullHeart.GetComponent<Animator>();
        thirdHeartAnimation = thirdFullHeart.GetComponent<Animator>();
        firstImage = firstFullHeart.GetComponent<Image>();
        secondImage = secondFullHeart.GetComponent<Image>();
        thirdImage = thirdFullHeart.GetComponent<Image>();
        passwordLaptop = "paris";
        passwordLaptopFolder = 1874358;
        passwordSafe = "210305";
        passwordFireExtinguisher = "FIRE";
        diary = GameObject.Find("Diary");
        clothes = GameObject.Find("clothes");
        potal = GameObject.Find("portal");
        countInFire = 3;

        GameObjectSetActiveFalse(diary.transform.GetChild(1).gameObject);
        GameObjectSetActiveFalse(potal);
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
                DamageFirstHeart();
            }
            else if (life == 2)
            {
                DamageSecondHeart();
            }
            else if (life == 3)
            {
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
        UiManager.Instance.goToMenuButton.GetComponent<Button>().onClick.AddListener(() => ReloadScene());

    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator UiGameEndCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        UiManager.Instance.UiGameEnd();
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

    public void CheckLaptopPassword()
    {

    }

    private void OnApplicationQuit()
    {
        Debug.Log("Game Exit");
    }
}