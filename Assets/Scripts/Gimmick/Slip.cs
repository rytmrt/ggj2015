using UnityEngine;
using System.Collections;

public class Slip : GimmickExecutor {

	// Use this for initialization
	void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider car)
    {
        if (car.tag == "Car" )
        {
            if (isRunning)
            {
                car.SendMessage("Slip");
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
