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
        this.isRunning = true;
	}

    void GimmickOn() {
        this.isRunning = true;
        this.renderer.enabled = true;
    }

    void GimmickOff()
    {
        this.isRunning = false;
        this.renderer.enabled = false;
    }
}
