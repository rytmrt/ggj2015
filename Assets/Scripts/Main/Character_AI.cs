using UnityEngine;
using System.Collections;

/// <summary>
/// キャラがポイントに向かって進む処理
/// 行ったり来たりする
/// </summary>
public class Character_AI : MonoBehaviour 
{
	private const float RUN_SPEED = 5.0f;
	private const float WALK_SPEED = 2.0f;

	public GameObject[] point = new GameObject[3];
	public bool isRun;

	private bool isMove;
	private int next_point;
	private int length;
	private int plus;
	private float speed;
	private float time_cnt;

	[SerializeField]
	private float wait_time = 1.0f;
	private float reborn_time = 3.0f;

	private IEnumerator Start () 
	{
		yield return new WaitForSeconds(wait_time);
		transform.position = point[0].transform.position;
		plus = 1;
		isMove = true;
		next_point = 1;
		speed = (isRun) ? RUN_SPEED : WALK_SPEED;
		length = point.Length;
	}

	void Update ()
	{
		if (isMove)
		{
			var vec = (point[next_point].transform.position - transform.position).normalized;
			transform.position += vec * speed * Time.deltaTime;
			var dis = Vector3.Distance(transform.position, point[next_point].transform.position);
			if (dis < 0.5f) { Next_Point_Go(); }
			Debug.Log(next_point);
		}
		else
		{
			time_cnt += Time.deltaTime;
			if (time_cnt > reborn_time)
			{
				time_cnt = 0.0f;
				StartCoroutine("Start");
			}
		}
	}

	/// <summary>
	/// 次のポイントに行くための準備
	/// </summary>
	private void Next_Point_Go()
	{
		if (next_point >= (length-1) || next_point <= 0)
			plus = -plus;
		next_point += plus;
		transform.LookAt(point[next_point].transform);
		
	
	}

	/// <summary>
	/// キャラが穴に落ちる
	/// </summary>
	public  void Fall()
	{
		isMove = false;
		GetComponent<Collider>().enabled = false;
	}




}
