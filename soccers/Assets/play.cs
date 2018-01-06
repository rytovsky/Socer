using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class play : MonoBehaviour {

	public Text wynik;
	public static int redScore = 0;
	public static int blueScore = 0;
	public GameObject ball;
	public GameObject bramkaRed;
	public GameObject bramkaBlue;
	public Vector3 ballStartPosition;
	public void Start()
	{
		wynik.text = redScore + "   " + blueScore;
		ball = GameObject.FindGameObjectWithTag ("Ball");
		ballStartPosition = ball.transform.position;

	}

	public void Update()
	{
		if (bramkaRed.GetComponent<bramkaCollider> ().goall) 
		{
			addScore ("blue");
			bramkaRed.GetComponent<bramkaCollider> ().goall = false;
		}
		else if (bramkaBlue.GetComponent<bramkaCollider> ().goall) 
		{
			addScore ("red");
			bramkaBlue.GetComponent<bramkaCollider> ().goall = false;
		}
		wynik.text = redScore + "   " + blueScore;
			
		if(Input.GetKey(KeyCode.A))
		{
				ballStart();	
		}	
	}
	public void addScore(string name )
	{
		if (name == "blue") 
		{
			blueScore += 1;
		}
		else if (name == "red") 
		{
			redScore += 1;
		}
		ballStart ();
	}
	public void ballStart()
	{
		ball.GetComponent<Rigidbody> ().isKinematic = true;
		ball.transform.position = ballStartPosition; 
		ball.GetComponent<Rigidbody> ().isKinematic = false;


	}

}
