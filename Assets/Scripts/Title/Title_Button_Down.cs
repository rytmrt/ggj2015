using UnityEngine;
using System.Collections;

/// <summary>
/// タイトルシーンでのボタンを押した時の処理
/// </summary>
public class Title_Button_Down : MonoBehaviour 
{

	/// <summary>
	/// タイトルのスタートボタンを押した時の処理
	/// </summary>
	public void Start_Button_Down()
	{
		if (!FadeManager.Instance.isFading)
		{
			FadeManager.Instance.LoadLevel("Stage_1", 0.5f);
		}
	}

	/// <summary>
	/// タイトルのエンドボタンを押した時の処理
	/// </summary>
	public void End_Button_Down()
	{
		if (!FadeManager.Instance.isFading)
		{
			Application.Quit();
		}
	}
}
