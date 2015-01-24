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
        this.child.SendMessage("GimmickOn");
    }
    public void GimmickOff()
    {
        this.child.SendMessage("GimmickOff");
    }
}
