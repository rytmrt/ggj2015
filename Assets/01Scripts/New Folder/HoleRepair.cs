using UnityEngine;
using System.Collections;

public class HoleRepair : MonoBehaviour {

    GameObject[] holes;

    int i = 0;

	// Use this for initialization
	void Start () {
        holes = GameObject.FindGameObjectsWithTag("Hole");
	
	}
	
	// Update is called once per frame
	void Update () {
	}



    public void Repair() {
/*        if (i < holes.Length)
        {
           
            i++;
        }*/
        holes[0].SendMessage("GimmickOff");
    }


}
