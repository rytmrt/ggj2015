using UnityEngine;
using System.Collections;

public class HoleRepair : MonoBehaviour {

    GameObject[] holes;

    int i = 0;

    float[] timeCount;
    float MAX_TIME = 3.0f;

	// Use this for initialization
	void Start () {
        holes = GameObject.FindGameObjectsWithTag("Hole");
        timeCount = new float[holes.Length];
	
	}
	

	// Update is called once per frame
	void Update () {
            for (int i = 0; i < holes.Length; i++)
            {
                if(!holes[i].GetComponent<Fall>().isRunning)
                {
                    timeCount[i] += Time.deltaTime;

                    if (timeCount[i] >= MAX_TIME)
                    {
                        GimmickOn(i);
                        timeCount[i] = 0;
                    }
                }
            }
	}
    


    public void Repair0() {
        GimmickOff(0);
    }

    public void Repair1() {
        GimmickOff(1);
    }

    public void Repair2() {
        GimmickOff(2);
    }


    void GimmickOff(int index)
    {
        holes[index].SendMessage("GimmickOff");
    }
    void GimmickOn(int index) {
        holes[index].SendMessage("GimmickOn");
    }


}
