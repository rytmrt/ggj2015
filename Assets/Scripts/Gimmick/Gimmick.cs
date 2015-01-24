using UnityEngine;
using System.Collections;

public class Gimmick : MonoBehaviour {
    GameObject child;
	// Use this for initialization
	void Start () {
        child = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GimmickOn()
    {
        Debug.Log("GimmickOff");
        child.SendMessage("GimmickOn");
    }
    public void GimmickOff()
    {
        Debug.Log("GimmickOn");
        child.SendMessage("GimmickOff");
    }
}
