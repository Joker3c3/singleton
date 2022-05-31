using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

[System.Serializable]
public class SaveData {
    public List<DbFormat> testData = new List<DbFormat>();
}

public class DBManager : MonoBehaviour
{
    string path;
    private static DBManager instance;
    public static DBManager Instance { get => instance; }
    public List<DbFormat> dataBase = new List<DbFormat>();
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
        path = Path.Combine(Application.persistentDataPath, "database.json");
        JsonLoad();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void JsonLoad()
    {
        SaveData saveData = new SaveData();

        if (!File.Exists(path))
        {
            JsonSave();
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);
            List<DbFormat> sortDataBase = new List<DbFormat>();

            if (saveData != null)
            {
                if (saveData.testData.Count <= 5)
                {
                    sortDataBase = saveData.testData.OrderBy(x => x.rankingScore).ToList();
                    for (int i = 0; i < saveData.testData.Count; i++)
                    {
                        dataBase.Add(sortDataBase[i]);
                    }
                    sortDataBase = dataBase.OrderBy(x => x.rankingScore).ToList();
                }
                else
                {
                    sortDataBase = saveData.testData.OrderBy(x => x.rankingScore).ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        dataBase.Add(sortDataBase[i]);
                    }
                }
            }
        }
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        for (int i = 0; i<dataBase.Count; i++)
        {
            saveData.testData.Add(dataBase[i]);
        }
        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }

    public void SetDatabaseAdd(string userName, int score)
    {
        // DbFormat user1 = new DbFormat("김영인", 1000);
        // DbFormat user2 = new DbFormat("이우형", 2000);
        // DbFormat user3 = new DbFormat("임규형", 3000);
        // DbFormat user4 = new DbFormat("백승연", 4000);
        // DbFormat user5 = new DbFormat("홍길동", 5000);
        // dataBase.Add(user1);
        // dataBase.Add(user2);
        // dataBase.Add(user3);
        // dataBase.Add(user4);
        // dataBase.Add(user5);
        DbFormat user = new DbFormat(userName, score);
        dataBase.Add(user);
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
