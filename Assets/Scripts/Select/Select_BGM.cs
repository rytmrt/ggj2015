using UnityEngine;
using System.Collections;

public class Select_BGM : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioManager.Instance.StopBGM ();
		AudioManager.Instance.PlayBGM ("MaoSoulBGM-Select", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
