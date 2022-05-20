using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsCollisionBodyFire : MonoBehaviour
{
    public int tmp = 0;
    public GameObject firstFullHeart;
    public GameObject secondFullHeart;
    public GameObject thirdFullHeart;
    public Animator firstHeartAnimation;
    public Animator secondHeartAnimation;
    public Animator thirdHeartAnimation;
    public Image firstImage;
    public Image secondImage;
    public Image thirdImage;
    // Start is called before the first frame update
    void Start()
    {
        firstFullHeart = transform.Find("First Full Heart").gameObject;
        secondFullHeart = transform.Find("Second Full Heart").gameObject;
        thirdFullHeart = transform.Find("Third Full Heart").gameObject;

        InitializedCanvasContent(firstFullHeart, firstHeartAnimation, firstImage);
        InitializedCanvasContent(secondFullHeart, secondHeartAnimation, secondImage);
        InitializedCanvasContent(thirdFullHeart, thirdHeartAnimation, thirdImage);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void InitializedCanvasContent(GameObject canvasContent, Animator animator, Image image)
    {
        if (!canvasContent)
        {
            if (!animator)
            {
                animator = canvasContent.GetComponent<Animator>();
            }
            else
            {
                Debug.Log("cannot find animator");
            }
            if (!image)
            {
                image = canvasContent.GetComponent<Image>();
            }
            else
            {
                Debug.Log("cannot find image");
            }
        }
        else
        {
            Debug.Log("cannot find canvasContents");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.tag == "fire")
            {
                if (GameManager.Instance.getLife() == 0)
                {
                    // Game Over
                    GameManager.Instance.isGameEnd = true;

                    //create reset your game

                }

                GameManager.Instance.changeFlagIsCollisionBodyFire();

                if (GameManager.Instance.isCollisionBodyFire && GameManager.Instance.getLife() == 3)
                {
                    tmp = GameManager.Instance.getLife() - 1;
                    GameManager.Instance.changeFlagIsLifeChanged();
                    GameManager.Instance.setLife(tmp);
                    UiManager.Instance.EnableAnimation(thirdFullHeart, thirdHeartAnimation, thirdImage);
                    GameManager.Instance.changeFlagIsLifeChangedEnd();
                    GameManager.Instance.isCollisionBodyFire = false;
                }

                if (GameManager.Instance.isCollisionBodyFire && GameManager.Instance.getLife() == 2)
                {
                    tmp = GameManager.Instance.getLife() - 1;
                    GameManager.Instance.changeFlagIsLifeChanged();
                    GameManager.Instance.setLife(tmp);
                    UiManager.Instance.EnableAnimation(secondFullHeart, secondHeartAnimation, secondImage);
                    GameManager.Instance.changeFlagIsLifeChangedEnd();
                    GameManager.Instance.isCollisionBodyFire = false;
                }

                if (GameManager.Instance.isCollisionBodyFire && GameManager.Instance.getLife() == 1)
                {
                    tmp = GameManager.Instance.getLife() - 1;
                    GameManager.Instance.changeFlagIsLifeChanged();
                    GameManager.Instance.setLife(tmp);
                    UiManager.Instance.EnableAnimation(firstFullHeart, firstHeartAnimation, firstImage);
                    GameManager.Instance.changeFlagIsLifeChangedEnd();
                    GameManager.Instance.isCollisionBodyFire = false;
                }
            }
            else
            {
                Debug.Log("Is not fire. You are safe");
            }
        }
        else
        {
            Debug.Log("Collider parameter missing");
        }
    }
}

