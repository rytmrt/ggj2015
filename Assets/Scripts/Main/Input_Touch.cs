using UnityEngine;
using System.Collections;

public class Input_Touch : MonoBehaviour
{
	float distance = float.MaxValue; // Rayの届く距離

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if (Physics.Raycast(ray, out hit, distance))
			{
				GameObject selectedGameObject = hit.collider.gameObject;
				TapBehaviour target = selectedGameObject.GetComponent(typeof(TapBehaviour)) as TapBehaviour;
				if (target != null)
				{
					target.TapDown(ref hit);
				}
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(ray, out hit, distance))
			{
				GameObject selectedGameObject = hit.collider.gameObject;
				TapBehaviour target = selectedGameObject.GetComponent(typeof(TapBehaviour)) as TapBehaviour;
				if (target != null)
				{
					target.TapUp(ref hit);
				}
			}
		}
	}
}
