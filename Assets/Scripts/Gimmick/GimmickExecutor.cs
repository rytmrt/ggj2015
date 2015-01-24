using UnityEngine;
using System.Collections;

public class GimmickExecutor : MonoBehaviour {

    protected bool isRunning;

    //ギミックが動いているかどうかを取得する
    public bool running {
        get { return isRunning; }
    }

	// Use this for initialization
	protected void Start () {
        this.GimmickOff();
	}

    //ギミック作動
    void GimmickOn() {
        this.isRunning = true;
        this.renderer.enabled = true;
    }

    //ギミック停止
    void GimmickOff()
    {
        this.isRunning = false;
        this.renderer.enabled = false;
    }
}
