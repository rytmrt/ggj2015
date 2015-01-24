using UnityEngine;
using System.Collections;

/// <summary>
/// セレクト画面でのボタンアクション用
/// </summary>
public class Select_Button_Down : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Stage_1_Button_Down()
	{
		FadeManager.Instance.LoadLevel("Stage_1", 0.5f);
	}
}
