using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class DbFormat
{
    public string userName;
    public int rankingScore;
    
    public DbFormat() {
        this.userName = GameManager.Instance.userName;
        this.rankingScore = GameManager.Instance.rankingScore;
    }
    public DbFormat(
        string userName,
        int rankingScore
    )
    {
        this.userName = userName;
        this.rankingScore = rankingScore;
    }
}
