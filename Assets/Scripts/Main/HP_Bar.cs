using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HP_Bar : MonoBehaviour 
{
	public Image hp_bar;
	public Text hp_text;

	private float hp_part;

	void Start()
	{
		hp_part = 1.0f / 1000.0f;
	}

	void Update()
	{
		var hp_percent = hp_part * (float)ScoreMgr.happiness;
		hp_bar.transform.localScale = new Vector3(hp_percent, 1, 1);
		hp_bar.color = (hp_percent > 0.2f) ? Color.green : Color.red;
		hp_text.text = hp_percent.ToString("f1") + "%";
		Debug.Log(hp_percent);
	}

}
