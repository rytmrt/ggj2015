using UnityEngine;
using System.Collections;

/// <summary>
/// オブジェクトがポイントに向かって進む処理
/// 行ったり来たりする
/// </summary>
public class Base_AI : MonoBehaviour 
{
	private const float RUN_SPEED = 5.0f;
	private const float WALK_SPEED = 2.0f;
	private const float REBORN_TIME = 5.0f;

	public GameObject[] point = new GameObject[3];
	public bool isRun;
	public bool isLoop;
	protected bool isMove;
	protected bool isReBorn;

	private int next_point;
	private int length;
	private int plus;
	private float speed;
	private float time_cnt;

	protected void Start () 
	{
		transform.position = point[0].transform.position;
		GetComponent<Collider>().enabled = true;
		plus = 1;
		isMove = true;
		next_point = 1;
		speed = (isRun) ? RUN_SPEED : WALK_SPEED;
		length = point.Length;
	}

	protected void Update ()
	{
		if (isMove)
		{
			var vec = (point[next_point].transform.position - transform.position).normalized;
			transform.position += vec * speed * Time.deltaTime;
			var dis = Vector3.Distance(transform.position, point[next_point].transform.position);
			if (dis < 0.5f) { Next_Point_Go(); }
		}
		else if (isReBorn)
		{
			time_cnt += Time.deltaTime;
			if (time_cnt > REBORN_TIME)
			{
				rigidbody.velocity = Vector3.zero;
				time_cnt = 0.0f;
				this.Start();
                transform.LookAt(point[next_point].transform);
			}
		}
	}

	/// <summary>
	/// 次のポイントに行くための準備
	/// </summary>
	private void Next_Point_Go()
	{
		if (isLoop)
		{
			if (next_point >= (length - 1))
				next_point = -1;
		}
		else
		{
			if (next_point >= (length - 1) || next_point <= 0)
				plus = -plus;
		}
		next_point += plus;
		transform.LookAt(point[next_point].transform);
	}

}
