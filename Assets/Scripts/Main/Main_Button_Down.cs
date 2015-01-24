using UnityEngine;
using System.Collections;

public class Main_Button_Down : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void End_Button_Down()
	{
		FadeManager.Instance.LoadLevel("Result", 0.5f);
	}
}
