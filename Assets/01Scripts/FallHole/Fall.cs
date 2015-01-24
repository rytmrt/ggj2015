using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider chara) {
        Vector3 charaPos = transform.position;
        if (chara.tag == "Player")
        {
            chara.SendMessage("Fall");
            charaPos.y = chara.transform.position.y;
            chara.transform.position = charaPos;
        }
    }
}
