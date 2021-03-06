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
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DBManagerInstanceReset()
    {
        dataBase = new List<DbFormat>();
        path = Path.Combine(Application.persistentDataPath, "database.json");
        JsonLoad();
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
