using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour
{
	// タッチの初期位置
	private readonly Vector2 INITIAL_TOUCH_POS = new Vector2(-1, -1);
	// 移動を無視する長さ
	[SerializeField] private float ignoreLength;
	// 移動量
	[SerializeField] private float movementRate;
	// カメラが見る場所
	[SerializeField] private GameObject lookAtTerget;
	// タッチ開始位置
	private Vector2 touchStartPos;
	private Vector2 prevTouchPos;

	void Start ()
	{
		this.inisializeTouchPos();
		var tergetPos = this.transform.forward * 10;
	}

	void Update ()
	{
		this.transform.LookAt(lookAtTerget.transform);
		// カメラを回す
		this.RotateCamera ();
		// カメラをズームする
		this.ZoomCamera ();
	}

	// タッチ位置を初期化
	private void inisializeTouchPos() {
		this.touchStartPos = this.INITIAL_TOUCH_POS;
		this.prevTouchPos = this.INITIAL_TOUCH_POS;
	}

	// カメラを回す
	private void RotateCamera ()
	{
		// タッチしている数が2つである
		var touchNum = InputMgr.GetTouchCount ();
		if (touchNum == 2) {
			var touchState = InputMgr.GetTouchState (0);
			if (touchState == TOUCH_STATE.DOWN) { // タッチ開始
				// 開始位置を保存
				var touchPos = InputMgr.GetTouchScreenPos (0) + InputMgr.GetTouchScreenPos (1);
				touchPos *= 0.5f;
				this.touchStartPos = touchPos;
			}
			else if (touchState == TOUCH_STATE.MOVE) { // 移動中
				// 現在のタッチ位置を取得
				var touchPos = InputMgr.GetTouchScreenPos (0) + InputMgr.GetTouchScreenPos (1);
				touchPos *= 0.5f;
				// タッチ開始時より一定距離離れている
				var distance = Vector2.Distance (this.touchStartPos, touchPos);
				if (distance > this.ignoreLength) {
					// 前回のタッチ座標が初期位置でなければカメラを移動
					if (this.prevTouchPos != this.INITIAL_TOUCH_POS) {
						// 回転方向を取得
						var direction = this.prevTouchPos - touchPos;
						float angle = direction.x > 0 ? 1.0f : direction.x < 0 ? -1.0f : 0;
						// 回す！
						this.transform.RotateAround(this.lookAtTerget.transform.position, Vector3.up, angle * this.movementRate);
					}
					// タッチ座標を1つ前として登録
					this.prevTouchPos = touchPos;
				}
			}
			else if (touchState != TOUCH_STATE.MOVE && touchState != TOUCH_STATE.DOWN) { // 開始と移動以外
				// 初期化
				this.inisializeTouchPos();
			}
		}
	}

	// カメラをズームする
	private void ZoomCamera ()
	{
	}

}
