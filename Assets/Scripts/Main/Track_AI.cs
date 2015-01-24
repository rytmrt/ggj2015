using UnityEngine;
using System.Collections;

/// <summary>
/// トラック用のAI
/// </summary>
public class Track_AI : Base_AI
{
	private const float MOVE_SPEED = 3.0f;
	private const float SPIN_SPEED = 100.0f;

	//move_speed 滑ってからの移動スピード
	//spin_speed くるくる回るスピード
	//attack_obj 回転しながらぶつかる建物

	public float move_speed = MOVE_SPEED;
	public float spin_speed = SPIN_SPEED;
	public GameObject attack_obj;

	private bool isSpin;

	void Start ()
	{
		base.Start();
	}

	void Update ()
	{
		base.Update();
		if (isSpin)
		{
			var vec = (new Vector3(attack_obj.transform.position.x,0,attack_obj.transform.position.z) - transform.position).normalized;
			transform.Rotate(0, 10 * spin_speed * Time.deltaTime, 0);
			transform.position += new Vector3(vec.x,0,vec.z) * move_speed * Time.deltaTime;
			var dis = Vector3.Distance(transform.position, new Vector3(attack_obj.transform.position.x, 0, attack_obj.transform.position.z));
			if (dis < 2.5f)
			{
				//***衝突音***
				isSpin = false;
				isReBorn = true;
			}
		}
	}

	/// <summary>
	/// SendMessage("Slip")と送られてきた
	/// </summary>
	void Slip()
	{
	//	GetComponent<Collider>().enabled = false;
		isMove = false;
		isSpin = true;
	}
}
