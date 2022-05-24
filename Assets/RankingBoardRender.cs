using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankingBoardRender : MonoBehaviour
{
    public GameObject prefab;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RenderRankingBoard();
    }

    public void RenderRankingBoard()
    {
        Debug.Log(prefab);
        Debug.Log(parent);
        int nowPosY = 0;
        int count = 1;

        foreach (DbFormat db in DBManager.Instance.DataBase)
        {
            GameObject rankingBoardInstance = Instantiate(prefab);
            rankingBoardInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = count.ToString();
            rankingBoardInstance.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = db.userName;
            rankingBoardInstance.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = db.rankingScore.ToString();

            rankingBoardInstance.transform.SetParent(parent.transform, false);

            count++;
            nowPosY -= 120;
        }
    }

    
}