using UnityEngine;
using System.Collections;

public class FadeManager : SingletonMonoBehaviour<FadeManager>
{
	private Texture2D blackTexture; // <summary>暗転用黒テクスチャ</summary>
	private float fadeAlpha = 0;	// <summary>フェード中の透明度</summary>
	public bool isFading = false;	// <summary>フェード中かどうか</summary>

	public void Awake()
	{
		if (this != Instance)
		{
			Destroy(this);
			return;
		}

		DontDestroyOnLoad(this.gameObject);		//ここで黒テクスチャ作る

		this.blackTexture = new Texture2D(32, 32, TextureFormat.RGB24, false);
		this.blackTexture.ReadPixels(new Rect(0, 0, 32, 32), 0, 0, false);
		this.blackTexture.SetPixel(0, 0, Color.white);
		this.blackTexture.Apply();
	}

	public void OnGUI()
	{
		if (!this.isFading)
			return;

		//透明度を更新して黒テクスチャを描画
		GUI.color = new Color(0, 0, 0, this.fadeAlpha);
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), this.blackTexture);
	}

	// 画面遷移
	// <param name='scene'>シーン名</param>
	// <param name='interval'>暗転にかかる時間(秒)</param>
	public void LoadLevel(string scene, float interval)
	{
		StartCoroutine(TransScene(scene, interval));
	}

	// シーン遷移用コルーチン
	// <param name='scene'>シーン名</param>
	// <param name='interval'>暗転にかかる時間(秒)</param>
	private IEnumerator TransScene(string scene, float interval)
	{
		//だんだん暗く
		this.isFading = true;
		float time = 0;
		while (time <= interval)
		{
			this.fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
			time += Time.deltaTime;
			yield return 0;
		}

		//シーン切替
		Application.LoadLevel(scene);

		//だんだん明るく
		time = 0;
		while (time <= interval)
		{
			this.fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
			time += Time.deltaTime;
			yield return 0;
		}

		this.isFading = false;
	}

}