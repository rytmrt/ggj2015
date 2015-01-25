using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultImage : MonoBehaviour {
    [SerializeField]
    Sprite miserable;

    [SerializeField]
    Sprite happy;

    Image img;

	// Use this for initialization
	void Start () {
        img = GetComponent<Image>();
        if (ScoreMgr.happiness >= ScoreMgr.MAX_HAPPINESS)
        {
            img.sprite = happy;
        }
        else 
        {
            img.sprite = miserable;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    


	}
}
