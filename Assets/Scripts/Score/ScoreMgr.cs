using UnityEngine;
using System.Collections;

public class ScoreMgr : MonoBehaviour {
    //現在の幸福値
    private static int nowHappiness;

    //助けた人数
    private static int saves;
    private static int notSaves;


    //最大の幸福値とスタートの幸福値
    public const int MAX_HAPPINESS = 1000;
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

    public static void addSaves()
    {
        saves++;
    }

    public static void addNotSaves() {
        notSaves++;
    }


	// Update is called once per frame
	void Update () {

        if (nowHappiness <= 0 || nowHappiness >= MAX_HAPPINESS)
        {
            FadeManager.Instance.LoadLevel("Result", 0.5f);
        }
	}
}
