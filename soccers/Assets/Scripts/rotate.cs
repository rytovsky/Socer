using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	public static float xValues = 0;
	public static float yValues = 0;

	public GameObject[] players;
	private void Start()
	{
		players = GameObject.FindGameObjectsWithTag ("Player");
	}
	public void Update()
	{
		for (int i = 0; i < players.Length; i++) 
		{
			if (players [i].GetComponent<distance> ().canUseForce) 
			{
				if (yValues >= 0)
					players[i].transform.eulerAngles = new Vector3 (transform.eulerAngles.x, (xValues * 90) + 90, transform.eulerAngles.z);
				else
					players[i].transform.eulerAngles = new Vector3 (transform.eulerAngles.x, (-180 - (xValues * 90)) + 90, transform.eulerAngles.z);
			}
		}


	}

}
