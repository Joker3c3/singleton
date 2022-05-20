using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }
    public bool isGameEnd = false;
    public bool isTowelCompleted = false;
    public bool isLifeEnd = false;
    public bool isTowelWet = false;

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
   
    public void ChangeFlagIsTowelCompleted()
    {
        this.isTowelCompleted = true;
    }

    public void changeFlagIsGameEnd()
    {
        this.isGameEnd = true;
    }

    public void changeFlagIsLifeEnd()
    {
        this.isLifeEnd = true;
    }

    public void changeFlagIsTowelWet()
    {
        this.isTowelWet = true;
    }
}
