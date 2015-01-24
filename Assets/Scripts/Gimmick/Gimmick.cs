using UnityEngine;
using System.Collections;

public class Gimmick : MonoBehaviour {
    GameObject child;
	// Use this for initialization
	void Start () {
        this.child = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	}


    public void GimmickOn()
    {
        Debug.Log("GimmickOff");
        this.child.SendMessage("GimmickOn");
    }
    public void GimmickOff()
    {
        Debug.Log("GimmickOn");
        this.child.SendMessage("GimmickOff");
    }
}
