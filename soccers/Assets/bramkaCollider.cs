using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bramkaCollider : MonoBehaviour {
	public bool goall = false;
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Ball")
			goall = true;

	}


}
