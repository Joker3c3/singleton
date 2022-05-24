using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    private static DBManager instance;
    public static DBManager Instance { get => instance; }
    private List<DbFormat> dataBase;
    public List<DbFormat> DataBase { get => dataBase; }
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDbTest()
    {
        dataBase = new List<DbFormat>();
        DbFormat user1 = new DbFormat("김영인", 1000);
        DbFormat user2 = new DbFormat("이우형", 2000);
        DbFormat user3 = new DbFormat("임규형", 3000);
        DbFormat user4 = new DbFormat("백승연", 4000);
        DbFormat user5 = new DbFormat("홍길동", 5000);

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
