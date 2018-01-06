using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalkepper : MonoBehaviour {

	public Transform targetRight;
	public Transform targetLeft;
	public float speed;
	private bool goRight = true;

	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		if (goRight) {
			transform.position = Vector3.MoveTowards (transform.position, targetRight.position, step);
			if (transform.position == targetRight.position)
				goRight = !goRight;
		} else {
			transform.position = Vector3.MoveTowards (transform.position, targetLeft.position, step);
			if (transform.position == targetLeft.position)
				goRight = !goRight;
		}
			
		

	}
}
