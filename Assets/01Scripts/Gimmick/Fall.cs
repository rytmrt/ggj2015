using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour
{
    bool isRunning;

	// Use this for initialization
	void Start () {
        isRunning = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //ギミックのオン、オフを切り替える
    void GimmickOn() {
        isRunning = true;
        renderer.enabled = true;
    }
    void GimmickOff() {
        isRunning = false;
        renderer.enabled = false;
    }



    void OnTriggerEnter(Collider chara) {
        Vector3 charaPos = transform.position;
        if (chara.tag == "Player" && isRunning)
        {
            chara.SendMessage("Fall");
            charaPos.y = chara.transform.position.y;
            chara.transform.position = charaPos;
        }
    }
}
