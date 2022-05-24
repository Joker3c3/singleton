using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    private static DBManager instance;
    public static DBManager Instance { get => instance; }
    private List<DbFormat> dataBase;
    public List<DbFormat> DataBase { get { return dataBase; } }
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
    // Start is called before the first frame update
    void Start()
    {
       setDbTest(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDbTest()
    {
        dataBase = new List<DbFormat>();
        DbFormat user1 = new DbFormat();
        user1.userName = "김영인";
        user1.rankingScore = 1000;

        DbFormat user2 = new DbFormat();
        user2.userName = "이우형";
        user2.rankingScore = 2000;

        DbFormat user3 = new DbFormat();
        user3.userName = "임규형";
        user3.rankingScore = 3000;

        DbFormat user4 = new DbFormat();
        user4.userName = "백승연";
        user4.rankingScore = 4000;

        DbFormat user5 = new DbFormat();
        user2.userName = "홍길동";
        user2.rankingScore = 5000;

        dataBase.Add(user1);
        dataBase.Add(user2);
        dataBase.Add(user3);
        dataBase.Add(user4);
        dataBase.Add(user5);

        ShowDataBaseList(dataBase);
    }

    public void ShowDataBaseList(List<DbFormat> database)
    {
        foreach(DbFormat db in database)
        {
            Debug.Log(db.userName);
            Debug.Log(db.rankingScore);
        }
    }
}
