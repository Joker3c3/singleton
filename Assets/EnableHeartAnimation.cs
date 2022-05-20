using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableHeartAnimation : MonoBehaviour
{
    public Animator heartAnimation;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        if(!heartAnimation)
        {
            heartAnimation = GetComponent<Animator>(); 
        }
        if(!image)
        {
            image = GetComponent<Image>();
        }
        heartAnimation.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableAnimation()
    {
        if(GameManager.Instance.isLifeChanged)
        {
            heartAnimation.enabled = true;
            Invoke("DisabledAnimation", 3f);
            image.enabled = false;            
        }
    }
    public void DisabledAnimation()
    {
        heartAnimation.enabled = false;
    }
}
