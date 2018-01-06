using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pochylanie : MonoBehaviour {
	public GameObject Model;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.transform.LookAt (Model.transform);
		
	}
}
