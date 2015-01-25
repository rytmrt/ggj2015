using UnityEngine;
using System.Collections;

public class CameraTergetControll : MonoBehaviour
{
	// タッチの初期位置
	private readonly Vector2 INITIAL_TOUCH_POS = new Vector2(-1, -1);
	// 移動を無視する長さ
	[SerializeField] private float ignoreLength;
	// 移動量
	[SerializeField] private float movementRate;
	// タッチ開始位置
	private Vector2 touchStartPos;
	private Vector2 prevTouchPos;

	void Start ()
	{
		this.inisializeTouchPos();
	}

	void Update ()
	{
		// カメラを動かす
		this.MoveCamera ();
	}

	// タッチ位置を初期化
	private void inisializeTouchPos() {
		this.touchStartPos = this.INITIAL_TOUCH_POS;
		this.prevTouchPos = this.INITIAL_TOUCH_POS;
	}

	// カメラを動かす
	private void MoveCamera ()
	{
		// タッチしている数が1つである
		var touchNum = InputMgr.GetTouchCount ();
		if (touchNum == 1) {
			var touchState = InputMgr.GetTouchState (0);
			if (touchState == TOUCH_STATE.DOWN) { // タッチ開始
				// 開始位置を保存
				this.touchStartPos = InputMgr.GetTouchScreenPos (0);
			} else if (touchState == TOUCH_STATE.MOVE) { // 移動中
				// 現在のタッチ位置を取得
				var touchPos = InputMgr.GetTouchScreenPos (0);
				// タッチ開始時より一定距離離れている
				var distance = Vector2.Distance (this.touchStartPos, touchPos);
				if (distance > this.ignoreLength) {
					// 前回のタッチ座標が初期位置でなければカメラを移動
					if (this.prevTouchPos != this.INITIAL_TOUCH_POS) {
						// 移動方向を取得
						var movementDirection = this.prevTouchPos - touchPos;
						movementDirection.Normalize ();
						// 移動量を調整
						var movementDistance = Vector2.Distance (this.prevTouchPos, touchPos);
						movementDistance *= movementRate;
						var movement = movementDirection * movementDistance;
						var movementv3 = Vector3.zero;
						movementv3.Set (movement.x, 0.0f, movement.y);
						// 移動させる
						transform.position += movementv3;
					}
					// タッチ座標を1つ前として登録
					this.prevTouchPos = touchPos;
				}
			} else { // その他
				// 初期化
				this.inisializeTouchPos();
			}
		}
	}
}
