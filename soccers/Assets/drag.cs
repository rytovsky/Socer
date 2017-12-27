using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour {

	Vector3 currentPosition;
	public Vector3 wzgledna;
	bool dragEnd = false;
	public float maxX = 1f;
	public float maxZ = 1f;
	public Vector3 pozycjaPoczatkowa;

	public float timer = 0f;
	public float maxTimer = 0f;

	void Start()
	{
		pozycjaPoczatkowa = transform.position;
	}
	void Update()
	{
		/*Debug.Log ("X: " + Input.mousePosition.x);
		Debug.Log ("Y: " + Input.mousePosition.y);
		Debug.Log ("Z: " + Input.mousePosition.z);*/

		if (transform.position.x > pozycjaPoczatkowa.x + maxX) {
			transform.position = new Vector3(pozycjaPoczatkowa.x + maxX,transform.position.y,transform.position.z) ;
		}
		if (transform.position.z > pozycjaPoczatkowa.z + maxZ)
			transform.position = new Vector3(transform.position.x,transform.position.y,pozycjaPoczatkowa.z + maxZ) ;

		if (dragEnd) 
		{
			
			timer += Time.deltaTime;

			if (timer > maxTimer) 
			{
				dragEnd = false;
				timer = 0;
				transform.position = pozycjaPoczatkowa;
			}
		}
	
	}
	void OnMouseDown()
	{
		
		wzgledna = Input.mousePosition;
	}
	void OnMouseDrag()
	{
		
		transform.position = new Vector3 (transform.position.x+((wzgledna.y - Input.mousePosition.y)/-200), 2.32f,transform.position.z+((wzgledna.x - Input.mousePosition.x)/200));

		//currentPosition = Input.mousePosition.
		//currentPosition.y = 2.07f;	

		//transform.position = currentPosition;
	}


	void OnMouseUp() {
		
		dragEnd = true;
	}
}
