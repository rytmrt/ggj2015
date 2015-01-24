using UnityEngine;
using System.Collections;

public class Title_BGM : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioManager.Instance.PlayBGM ("MaoSoulBGM-Title",true);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
