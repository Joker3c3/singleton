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
    public bool isLifeChanged = false;
    public bool isCollisionBodyFire = false;
    private int life;

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
        setLife(3);
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

    public void changeFlagIsCollisionBodyFire()
    {
        this.isCollisionBodyFire = true;
    }

    public void changeFlagIsLifeChanged()
    {
        this.isLifeChanged = true;
    }

    public void changeLife()
    {
        this.life--;
    }

    public void setLife(int value)
    {
        this.life = value;
    }

    public int getLife()
    {
        return this.life;
    }

    public void changeFlagIsLifeChangedEnd()
    {
        this.isLifeChanged = false;
    }
}
