using UnityEngine;
using System.Collections;

public abstract class TapBehaviour : MonoBehaviour {
    // タッチしたときに呼ばれる。
    public virtual void TapDown(ref RaycastHit hit){}
    // タッチを離したときに呼ばれる。
    public virtual void TapUp(ref RaycastHit hit){}
}
