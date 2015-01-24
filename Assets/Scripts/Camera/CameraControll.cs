using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour
{
		// 移動を無視する長さ
		[SerializeField]
		private float ignoreLength;
		[SerializeField]
		private float movementRate;

		// タッチ開始位置
		private Vector2 touchStartPos;
		private Vector2 prevTouchPos;

		void Start ()
		{
				this.ignoreLength = 1.0f;
		}

		void Update ()
		{
				// カメラを動かす
				this.MoveCamera ();
				// カメラを回す
				this.RotateCamera ();
				// カメラをズームする
				this.ZoomCamera ();
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
										// 移動方向を取得
										var movementDirection = this.prevTouchPos - touchPos;
										movementDirection.Normalize ();
										// 移動量を調整
										distance *= movementRate;
										var movementv2 = movementDirection * distance;
										var movementv3 = Vector3.zero;
										movementv3.Set (movementv2.x, 0, movementv2.y);
										// 差分を移動させる
										transform.position += movementv3;
										// タッチ座標を1つ前として登録
										this.prevTouchPos = touchPos;
								}
						} else { // その他
								// 開始位置を初期化
								this.touchStartPos.Set (-1, -1);
						}
				}
		}

		// カメラを回す
		private void RotateCamera ()
		{
		}

		// カメラをズームする
		private void ZoomCamera ()
		{
		}

}
