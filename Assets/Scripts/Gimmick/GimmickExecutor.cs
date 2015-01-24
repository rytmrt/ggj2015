using UnityEngine;
using System.Collections;

public class GimmickExecutor : MonoBehaviour {
    enum RiskRank{
        S,
        A,
        B,
    }


    protected bool isRunning;

    [SerializeField]
    RiskRank rank;

    int[] HAPPINESS_TABLE = { 50, 20, 10 };

    protected bool ArleadyAdd;

    //ギミックが動いているかどうかを取得する
    public bool running {
        get { return isRunning; }
    }

	// Use this for initialization
	protected void Start () {
        this.GimmickOff();
        ArleadyAdd = true;
	}

    //ギミック作動
    void GimmickOn() {
        this.isRunning = true;
        this.renderer.enabled = true;
        this.ArleadyAdd = false;
    }

    //ギミック停止
    void GimmickOff()
    {
        this.isRunning = false;
        this.renderer.enabled = false;
    }

    protected void OnContactInRunning() {
        ScoreMgr.addHappiness(-HAPPINESS_TABLE[(int)rank]);
    }
    protected void OnContactInNotRunning()
    {
        ScoreMgr.addHappiness(HAPPINESS_TABLE[(int)rank]);
    }
}
