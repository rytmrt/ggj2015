using UnityEngine;
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
		if (col.name == "Track")
		{
			col.SendMessage("Slip");
			Destroy(this.gameObject);
		}
	}
}
