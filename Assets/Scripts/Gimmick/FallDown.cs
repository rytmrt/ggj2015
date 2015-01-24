using UnityEngine;
using System.Collections;


public class FallDown : GimmickExecutor {

	// Use this for initialization
	void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider chara)
    {
        Vector3 charaPos = transform.position;
        if (chara.tag == "Player")
        {
            if (isRunning)
            {
                chara.SendMessage("Slip");
                this.OnContactInRunning();
            }
            else
            {
                if (!ArleadyAdd)
                {
                    //幸福度加算処理
                    OnContactInNotRunning();
                    ArleadyAdd = true;
                }
            }
        }
    }
}
