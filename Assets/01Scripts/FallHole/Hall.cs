using UnityEngine;
using System.Collections;

public class Hall : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision chara)
    {
        Debug.Log("Run");
        if (chara.gameObject.tag == "Player")
        {
            chara.collider.enabled = false;
        }
    }
}
