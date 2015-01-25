using UnityEngine;
using System.Collections;

public class GimmickGroup : MonoBehaviour {
    //グループに属しているギミックとそのスクリプト
    GameObject[] gimmicks;
    Gimmick[] gimmickScript;

    //このグループのギミック起動最大数
    [SerializeField]
    int limitGimmicks;

    //ギミックの起動時間カウント
    float timeCounter;

    //このグループでギミックが起動する時間
    [SerializeField]
    float gimmickRunTime;

    //このグループ自体のギミックの動作状態
    bool gimmickSwitch;

	// Use this for initialization
	void Start () {
        //ギミックのオブジェクトとスクリプトを取得
       this.gimmicks = new GameObject[transform.childCount];
       gimmickScript = new Gimmick[gimmicks.Length];
       for (int i = 0; i < gimmicks.Length; i++)
       {
           gimmicks[i] = transform.GetChild(i).gameObject;
           gimmickScript[i] = gimmicks[i].GetComponent<Gimmick>();
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
            for (int i = 0; i < gimmicks.Length; i++)
            {
                if (gimmickScript[i].running)
                {
                    runningGimmicks++;
                }
            }

            //現在動いているギミック数が最大ギミック数を超えていなかったらいずれかのギミック作動
            if (runningGimmicks < limitGimmicks)
            {
                var runGimmickNum = Random.Range(0, gimmicks.Length);
                gimmicks[runGimmickNum].SendMessage("GimmickOn");
            }

            this.timeCounter = 0;

        }
    }

    //グループをオフにする処理
    void GroupOff() {
        for (int i = 0; i < gimmicks.Length; i++)
        {
            this.timeCounter = 0;
            this.gimmicks[i].SendMessage("GimmickOff");
        }
    }

    //グループをオンにする処理
    void GroupOn()
    {
        gimmickSwitch = true;
    }

	// Update is called once per frame
	void Update () {

        if (gimmickSwitch)
        {
            this.GimmickRun();
        }


	}
}
