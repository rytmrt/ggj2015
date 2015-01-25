using UnityEngine;
using System.Collections;

public class Tap_Event : TapBehaviour {

	public override void TapDown(ref RaycastHit hit)
	{
		// タップされたときの処理
	}

	public override void TapUp(ref RaycastHit hit)
	{
		// タップを離したときの処理
        GetComponent<Gimmick>().GimmickOff();
	}
}
