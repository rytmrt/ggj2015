using UnityEngine;
using System.Collections;

/// <summary>
/// ゲームを管理するスクリプト
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
	private int state;
	private int score;
	private int h_score;

	void Awake()
	{
		if (this != Instance)
		{
			Destroy(this);
			return;
		}
		DontDestroyOnLoad(this.gameObject);
	}

	/// <summary>
	/// 値を保存する関数
	/// </summary>
	public void Save_Score()
	{
		PlayerPrefs.SetInt("SAVE_SCORE", score);
	}

	/// <summary>
	/// 値をロードしてくる関数
	/// </summary>
	public void Load_Score()
	{
		h_score = PlayerPrefs.GetInt("SAVE_SCPRE");
	}

	/// <summary>
	/// スコアを加算する関数
	/// </summary>
	/// <param name="add_point">加算分のポイント</param>
	public void Add_Score(int add_point)
	{
		score += add_point;
	}
}
