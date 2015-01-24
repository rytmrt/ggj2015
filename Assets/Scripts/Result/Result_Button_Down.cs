using UnityEngine;
using System.Collections;

/// <summary>
/// リザルト画面のボタンアクション用
/// </summary>
public class Result_Button_Down : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Title_Button_Down()
	{
		FadeManager.Instance.LoadLevel("Title", 0.5f);
	}
}
