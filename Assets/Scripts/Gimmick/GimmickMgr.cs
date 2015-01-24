using UnityEngine;
using System.Collections;

public class GimmickMgr : MonoBehaviour {
    GameObject[] allGimmicks;
    Gimmick[] allGimmickScript;


    [SerializeField]
    int limitGimmicks;

    float timeCounter;

    [SerializeField]
    float gimmickRunTime;

	// Use this for initialization
	void Start () {
       this.allGimmicks = GameObject.FindGameObjectsWithTag("Gimmick");
       allGimmickScript = new Gimmick[allGimmicks.Length];
       for (int i = 0; i < allGimmicks.Length; i++)
       {
           allGimmickScript[i] = allGimmicks[i].GetComponent<Gimmick>();
       }
	}

    //ギミックの作動
    void GimmickRun() {
        int runningGimmicks = 0;

        this.timeCounter += Time.deltaTime;

        //ギミック作動時間になったら処理開始
        if (timeCounter >= gimmickRunTime)
        {
            //現在動いているギミックの数を取得
            for (int i = 0; i < allGimmicks.Length; i++)
            {
                if (allGimmickScript[i].running)
                {
                    runningGimmicks++;
                }
            }

            //現在動いているギミック数が最大ギミック数を超えていなかったらいずれかのギミック作動
            if (runningGimmicks < limitGimmicks)
            {
                var runGimmickNum = Random.Range(0, allGimmicks.Length);
                allGimmicks[runGimmickNum].SendMessage("GimmickOn");
            }

            this.timeCounter = 0;

        }
    }
	
	// Update is called once per frame
	void Update () {
        this.GimmickRun();
	}
}
