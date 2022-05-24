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
    public Animator firstHeartAnimation;
    public Animator secondHeartAnimation;
    public Animator thirdHeartAnimation;
    public Image firstImage;
    public Image secondImage;
    public Image thirdImage;
    public bool isTowelCompleted = false;
    public bool isLifeEnd = false;
    public bool isTowelWet = false;
    public bool isCollisionBodyFire = false;
    public bool isUserStateOverWhelming = false;
    private int life;
    public string userName;
    public int rankingScore;

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
        SetLife(3);
    }

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void ChangeFlagIsTowelCompleted()
    {
        this.isTowelCompleted = true;
    }

    public void ChangeFlagIsLifeEnd()
    {
        this.isLifeEnd = true;
    }

    public void ChangeFlagIsTowelWet()
    {
        this.isTowelWet = true;
    }

    public void ChangeFlagIsCollisionBodyFire()
    {
        this.isCollisionBodyFire = true;
    }

    public void ChangeFlagIsUserStateOverWhelming()
    {
        this.isUserStateOverWhelming = true;
    }

    public void ChangeLife()
    {
        this.life--;
    }

    public void SetLife(int value)
    {
        this.life = value;
    }

    public int GetLife()
    {
        return this.life;
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
        this.isTowelCompleted = false;
        this.isLifeEnd = false;
        this.isTowelWet = false;
        this.isCollisionBodyFire = false;
        this.isUserStateOverWhelming = false;
        this.life = 3;
        this.firstFullHeart = GameObject.Find("First Full Heart");
        this.secondFullHeart = GameObject.Find("Second Full Heart");
        this.thirdFullHeart = GameObject.Find("Third Full Heart");
        this.firstHeartAnimation = firstFullHeart.GetComponent<Animator>();
        this.secondHeartAnimation = secondFullHeart.GetComponent<Animator>();
        this.thirdHeartAnimation = thirdFullHeart.GetComponent<Animator>();
        this.firstImage = firstFullHeart.GetComponent<Image>();
        this.secondImage = secondFullHeart.GetComponent<Image>();
        this.thirdImage = thirdFullHeart.GetComponent<Image>();
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

    private void OnApplicationQuit()
    {
        Debug.Log("Game Exit");
    }
}