using UnityEngine;
using System.Collections;

public class Fall_Down : Base_AI {

	public float rotate_speed;
	public float slip_speed;
	public float slip_size;

	private float slip_cnt;
	private bool isFalldown;
	private bool isSlip;
	private bool isRotate;
	private Vector3 fall_vec;


	void Start ()
	{
		base.Start();
	}

	void Update ()
	{
		base.Update();
		if (isFalldown)
		{

			transform.position += fall_vec * slip_cnt * Time.deltaTime;
			if (isSlip && slip_cnt < 0)
				isSlip = false;
			if (isRotate && transform.localRotation.x > 0.5f)
				isRotate = false;
			if (isRotate)
				transform.Rotate(transform.right, rotate_speed);
			if (isSlip)
				slip_cnt -= Time.deltaTime * slip_speed;
		}
	}

	void FallDown()
	{
		fall_vec = transform.forward;
		slip_cnt = slip_size;
		isMove = false;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX |
								RigidbodyConstraints.FreezeRotationZ;
		//collider.enabled = false;
		isFalldown = true;
		isSlip = true;
		isRotate = true;
	}
}
