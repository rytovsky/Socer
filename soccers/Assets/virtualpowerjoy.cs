using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;


public class virtualpowerjoy : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {


		private Image bgImg;
		private Image joystickImg;
		private Vector3 inputVector;
		public float forceHit;
		public GameObject[] players;
		public odchylanie loc;


		private void Start()
		{
		    players = GameObject.FindGameObjectsWithTag ("Player");
			bgImg = GetComponent<Image> ();
			joystickImg = transform.GetChild (0).GetComponent<Image> ();
		}
		
	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImg.rectTransform, ped.position,ped.pressEventCamera,out pos)) 
		{

			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
			inputVector = new Vector3 (pos.x * 2 + 1, 0, pos.y * 2 - 1);
			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

			joystickImg.rectTransform.anchoredPosition = new Vector3 (0,	inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3));

			forceHit = Mathf.Abs(inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3));
			for (int i = 0; i < players.Length; i++) 
			{
				if (players [i].GetComponent<distance> ().canUseForce)
					players [i].GetComponentInChildren<odchylanie> ().localEn = forceHit;
				else {
					players [i].GetComponentInChildren<odchylanie> ().localEn = 0.0f;
				}

				
			}

		}
	}
		public virtual void OnPointerDown(PointerEventData ped)
		{
			OnDrag(ped);
		}
		public virtual void OnPointerUp(PointerEventData ped)
		{
			
			for (int i = 0; i < players.Length; i++) 
			{
				if (players [i].GetComponent<distance> ().canUseForce)
					players [i].GetComponent<distance> ().kick (forceHit);
			}

		
			inputVector = Vector3.zero;
			joystickImg.rectTransform.anchoredPosition = Vector3.zero;
		}


	}


