using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankingBoardRender : MonoBehaviour
{
    public GameObject prefab;
    public GameObject parent;
    public RankingBoardRender(
        GameObject prefab,
        GameObject parent
    )
    {
        this.prefab = prefab;
        this.parent = parent;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RenderRankingBoard()
    {
        Debug.Log(prefab);
        Debug.Log(parent);
        float nowPosY = 0.0f;
        int count = 1;
        // DBManager.Instance.setDbTest();

        foreach (DbFormat db in DBManager.Instance.DataBase)
        {
            GameObject rankingBoardInstance = Instantiate(prefab);
            rankingBoardInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = count.ToString();
            rankingBoardInstance.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = db.userName;
            rankingBoardInstance.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = db.rankingScore.ToString();

            rankingBoardInstance.transform.SetParent(parent.transform, true);
            Debug.Log(parent.transform);
            if (count == 1)
            {
                nowPosY = rankingBoardInstance.GetComponent<RectTransform>().localPosition.y;
            }
            rankingBoardInstance.GetComponent<RectTransform>().localPosition = new Vector3(rankingBoardInstance.GetComponent<RectTransform>().localPosition.x,
             nowPosY, rankingBoardInstance.GetComponent<RectTransform>().localPosition.z);

            count++;
            nowPosY -= 10.0f;
        }
    }


}