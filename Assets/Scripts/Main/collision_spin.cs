﻿using UnityEngine;
using System.Collections;

public class collision_spin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{

		col.SendMessage("FallDown");
		Destroy(this.gameObject);
	}
}
