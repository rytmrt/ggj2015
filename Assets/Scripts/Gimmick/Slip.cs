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
            Debug.Log("Run");
            if (isRunning)
            {
                car.SendMessage("Slip");
            }
            else 
            {
                //幸福度加算処理
            }
        }
    }
}
