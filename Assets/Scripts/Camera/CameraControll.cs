using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {
    Vector3 prevPos;
    Vector3 touchPos;

    [SerializeField]
    Vector2 max;

    [SerializeField]
    Vector2 min;

    [SerializeField]
    float speed;

    enum TouchMode{
        NONE,
        SINGLE,
        DOUBLE,
    }

    TouchMode mode;

    TOUCH_STATE prevState;

	// Use this for initialization
	void Start () {
        prevPos = Vector3.zero;
        touchPos = Vector3.zero;
        mode = TouchMode.NONE; 
	}

    void SlideMove()
    {
        touchPos = InputMgr.GetTouchScreenPos(0);

        if (InputMgr.GetTouchState(0) == TOUCH_STATE.MOVE)
        {
            touchPos = InputMgr.GetTouchScreenPos(0);

            Vector2 touchMove= prevPos - touchPos;
            touchMove.Normalize();

            touchMove *= speed;

            Vector3 cameraMove = Vector3.zero;
            cameraMove.Set(touchMove.x, 0, touchMove.y);



            transform.position += cameraMove;
        }


        //カメラの位置を制限する
        Vector3 camPos = transform.position;

        if (transform.position.x > max.x)
        {
            camPos.x = max.x;
            transform.position = camPos;
        }
        if (transform.position.x < min.x)
        {
            camPos.x = min.x;
            transform.position = camPos;
        }
        if (transform.position.z > max.y)
        {
            camPos.z = max.y;
            transform.position = camPos;
        }
        if (transform.position.z < min.y)
        {
            camPos.z = min.y;
            transform.position = camPos;
        }

        prevPos = touchPos;

    }

	// Update is called once per frame
	void Update () {
        switch (InputMgr.GetTouchCount())
        {
            case 1:
                SlideMove();
                break;
        }


	}
}
