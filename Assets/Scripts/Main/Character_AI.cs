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
	public bool isRun;
	public GameObject[] point = new GameObject[3];

	private int next_point;
	private int length;
	private int plus;
	private float speed;

	void Start () 
	{
		transform.position = point[0].transform.position;
		plus = 1;
		next_point = 1;
		speed = (isRun) ? RUN_SPEED : WALK_SPEED;
		length = point.Length;
	}

	void Update ()
	{
		var vec = (point[next_point].transform.position - transform.position).normalized;
		transform.position += vec * speed * Time.deltaTime;
		var dis = Vector3.Distance(transform.position, point[next_point].transform.position);
		if (dis < 0.5f) { Next_Point_Go(); }
		Debug.Log(next_point);
	}

	/// <summary>
	/// 次のポイントに行くための準備
	/// </summary>
	private void Next_Point_Go()
	{
		if (next_point >= (length-1) || next_point <= 0)
			plus = -plus;
		next_point += plus;
	}


}
