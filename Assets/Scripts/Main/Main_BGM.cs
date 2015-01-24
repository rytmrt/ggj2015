using UnityEngine;
using System.Collections;

public class Main_BGM : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioManager.Instance.PlayBGM ("MaoSoulBGM-City", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
