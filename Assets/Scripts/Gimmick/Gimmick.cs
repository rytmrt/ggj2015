using UnityEngine;
using System.Collections;

public class Gimmick : MonoBehaviour {
    GameObject child;

    bool isRunning;

    public bool running {
        get { return isRunning; }
    }

	// Use this for initialization
	void Start () {
        this.child = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        this.isRunning = child.GetComponent<GimmickExecutor>().running;
	}


    public void GimmickOn()
    {
        this.child.SendMessage("GimmickOn");
    }

    //ギミックをオフにする処理。グループからオフにされた場合には引数にtrueを渡す
    public void GimmickOff()
    {
        this.child.SendMessage("GimmickOff");
    }
}
