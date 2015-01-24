using UnityEngine;
using System.Collections;

/// <summary>
/// キャラ用のAI
/// </summary>
public class Human_AI : Base_AI
{
	private Human_AI base_class;

	void Start()
	{
		base.Start();
	}

	void Update()
	{
		base.Update();
	}

	/// <summary>
	/// キャラが穴に落ちる
	/// </summary>
	public void Fall()
	{
		isReBorn = true;
		isMove = false;
		GetComponent<Collider>().enabled = false;
	}

	void Slip()
	{
		isMove = false;

	}
}
