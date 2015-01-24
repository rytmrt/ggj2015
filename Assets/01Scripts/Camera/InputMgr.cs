using UnityEngine;
using System.Collections;

public enum TOUCH_STATE{
    UP,
    DOWN,
    MOVE,
    ERROR,
}

public class InputMgr : MonoBehaviour {

    //タッチの最大数とタッチの情報を保持するクラス
    public const byte TOUCH_MAX = 3;
    Touch TouchGetter;

    //タッチのステートと位置を保持する変数
    private static TOUCH_STATE[] TState;
    private static Vector2[] TouchPos;

    Vector3 TmpPos;

	// Use this for initialization
	void Start () {
        //配列の用意
        TState = new TOUCH_STATE[TOUCH_MAX];
        TouchPos = new Vector2[TOUCH_MAX];

       
        //変数の初期化
        for (int i = 0; i < TOUCH_MAX; i++)
        {
            TState[i] = TOUCH_STATE.UP;
            TouchPos[i] = Vector2.zero;
        }
	}
	
	// Update is called once per frame
	void Update () {
        TouchInput();
	}


    void TouchInput() {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                //タッチしている数がタッチの最大数を超えたらそれ以降は無視
                if (Input.touchCount > TOUCH_MAX) break;

                //タッチ情報を保持
                TouchGetter = Input.GetTouch(i);

                switch (TouchGetter.phase)
                {
                    case TouchPhase.Began://タッチ開始
                        TState[i] = TOUCH_STATE.DOWN;
                        break;
                    case TouchPhase.Moved://タッチされてから移動
                        TState[i] = TOUCH_STATE.MOVE;
                        break;
                    case TouchPhase.Ended://タッチをあげたとき
                        TState[i] = TOUCH_STATE.UP;
                        break;
                }

                //タッチ位置を設定
                TouchPos[i] = TouchGetter.position;
                TouchPos[i].x /= Screen.width;
                TouchPos[i].y /= Screen.height;


            }
        }
    }

    /// <summary>
    /// 入力状態を取得するメソッド
    /// </summary>
    /// <param name="index">タッチ情報が格納されている要素</param>
    /// <returns>その要素のタッチ状態</returns>
    public static TOUCH_STATE GetTouchState(int index) {
        if (index >= TOUCH_MAX) return TOUCH_STATE.ERROR;
        return TState[index];
    }

    /// <summary>
    /// タッチした位置を取得するメソッド
    /// </summary>
    /// <param name="index">タッチ情報が格納されている要素</param>
    /// <returns>その要素内のタッチ時の位置</returns>
    public static Vector2 GetTouchScreenPos(int index) {
        Vector2 tmp = Vector2.zero ;
        tmp.Set(TouchPos[index].x * Screen.width, TouchPos[index].y * Screen.height);
        return tmp;
    }

    public static int GetTouchCount()
    {
        return Input.touchCount;
    }

    /*
    void OnGUI() {
        if (Event.current.type == EventType.Repaint)
        {
            Graphics.DrawTexture(new Rect(0,0,100,100),tex,mat);
            Graphics.DrawTexture(new Rect(10, 10, 100, 100), tex, mat);
            Graphics.DrawTexture(new Rect(-10, -10, 100, 100), tex, mat);
        }
    }
    */
}
