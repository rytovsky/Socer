using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distance : MonoBehaviour {
	public GameObject wsk;
	public GameObject ball;
	public bool isSpring = false;
	SpringJoint sj;
	public float time = 0.0f;
	public float minTime = 3.0f;
	public bool canUseForce = false;
	public static bool shot = false;
	public static float forceShot = 0.0f;
	public float timeAfterShot = 0.0f;
	public bool isAfterShot = false;

	void Start () {
	
		ball = GameObject.FindGameObjectWithTag ("Ball");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!canUseForce && timeAfterShot > 3) 
		{
			isAfterShot = false;
			gameObject.transform.LookAt (ball.transform);
			//wsk.transform.position= new Vector3(0, 0, 0);
		}
			
		if (isAfterShot) {
			timeAfterShot += Time.deltaTime;

		}
		float dist = Vector3.Distance(ball.transform.position, transform.position);

		if (dist < 2 && !isSpring) 
		{
			addSpring ();

		}
		if (dist < 2) 
		{
			time += Time.deltaTime;
			if (time >= minTime) 
			{
				canUseForce = true;
			}
		
		}

		if (dist > 3.5 && isSpring) 
		{
			deleteSpring ();
			time = 0.0f;
			canUseForce = false;

		}

		
		if (canUseForce) 
		{
			stickBall ();
			deleteSpring ();
			if (shot) 
			{
				kick (forceShot);
			}
				
		}
	}

	void addSpring()
	{
		try
		{
			Destroy (ball.GetComponent<SpringJoint> ());
		}
		catch 
		{
			
		}
		isSpring = !isSpring;
		sj = ball.AddComponent<SpringJoint> () as SpringJoint;
		ball.GetComponent<SpringJoint>().connectedBody = gameObject.GetComponent<Rigidbody>();
		ball.GetComponent<SpringJoint> ().autoConfigureConnectedAnchor = false;
		ball.GetComponent<SpringJoint> ().connectedAnchor = new Vector3 (0,0,0);
		ball.GetComponent<SpringJoint> ().enableCollision = true;
	}
	void deleteSpring()
	{
		isSpring = false;

		Destroy (ball.GetComponent<SpringJoint> ());

	}
	void stickBall()
	{
		
		ball.transform.parent = gameObject.transform;
		ball.GetComponent<Rigidbody> ().isKinematic = true;
		ball.transform.LookAt (gameObject.transform);
		ball.transform.localPosition = new Vector3 (0, 0, 1);
	}

	void unStickBall()
	{
		ball.transform.parent = null;
		ball.GetComponent<Rigidbody> ().isKinematic = false;
	}
	public bool canShot()
	{
		if (canUseForce)
			return true;
		else
			return false;
	}
	public void kick(float force)
	{
		
		//wsk.transform.position= new Vector3(wsk.transform.position.x, wsk.transform.position.y, -1.0f);
		canUseForce = false;
		unStickBall ();
		time = 0.0f;
		ball.GetComponent<Rigidbody> ().AddForce (transform.forward * 80 * force);
		shot = false;
		Debug.Log ("Shot");
		isAfterShot = true;

	}

}
