using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Face : MonoBehaviour {
    [SerializeField]
    Sprite[] face;
    Image img;

	// Use this for initialization
	void Start () {
        img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        float parcent = (float)ScoreMgr.happiness/(float)ScoreMgr.MAX_HAPPINESS;
        int Expression =(int)(parcent / 0.25f);

        img.sprite = face[Expression];
	}
}
