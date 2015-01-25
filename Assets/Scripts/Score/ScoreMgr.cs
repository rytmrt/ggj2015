using UnityEngine;
using System.Collections;

public class ScoreMgr : MonoBehaviour {
    //現在の幸福値
    private static int nowHappiness;
    
    //最大の幸福値とスタートの幸福値
    private const int MAX_HAPPINESS = 1000;
    private const int START_HAPPINESS = 100;

    //現在の幸福値を取得
    public static int happiness {
        get { return nowHappiness; }
    }

	// Use this for initialization
	void Start () {
        nowHappiness = START_HAPPINESS;
	}

    //幸福値を増減させる
    public static void addHappiness(int add)
    {
        nowHappiness += add;
        if (nowHappiness > MAX_HAPPINESS) 
        {
            nowHappiness = MAX_HAPPINESS;
        }
        else if(nowHappiness < 0)
        {
            nowHappiness = 0;
        }
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Happiness="+nowHappiness);
	}
}
