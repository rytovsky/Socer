using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class odchylanie : MonoBehaviour {
	public float localEn = 0.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	if (GetComponentInParent<distance> ().canUseForce) {
			//Debug.Log ("Moge sie odchylac");
			gameObject.transform.eulerAngles = new Vector3 (localEn/-2, transform.eulerAngles.y, transform.eulerAngles.z);

		} else {
			gameObject.transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, transform.eulerAngles.z);

		}
			
		
	}
}
