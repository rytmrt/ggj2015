using UnityEngine;
using System.Collections;

public class GimmickMgr : MonoBehaviour {
    [SerializeField]
    GameObject[] gimmickGroups;

    //現在の段階
    int nowStage;

    [SerializeField]
    int[] StageArgHappiness;

	// Use this for initialization
	void Start () {
        nowStage = 0;
	}

    //段階によってギミックの動作数を増やす
    void StageExec() {
        if (nowStage < gimmickGroups.Length)
        {
            for (int i = 0; i < nowStage + 1; i++)
            {
                gimmickGroups[i].SendMessage("GroupOn");
            }
        }
    }

    //現在の段階をみる
    void StageGet() {

        Debug.Log(nowStage);
        for (int i = 0 ; i < StageArgHappiness.Length; i++)
        {
            if (StageArgHappiness[i] <= ScoreMgr.happiness)
            {
                Debug.Log("Run");

                if (i > nowStage)
                {
                    nowStage = i + 1;
                }
            }
        }

    }

	// Update is called once per frame
	void Update () {
        StageExec();
        StageGet();
	}
}
