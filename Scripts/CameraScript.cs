﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    
	public Transform target;
	public Vector3   offset;
	public bool useOffsetValues;
	public float rotateSpeed;
	public Transform pivot;

	public float maxViewAngle;
	public float minViewAngle;
	public bool invertY;
	// Use this for initialization
	void Start () {
		if(!useOffsetValues){
			offset = target.position - transform.position;
		}
		pivot.transform.position = target.transform.position;
	    pivot.transform.parent = target.transform;
		pivot.transform.parent =null;
		Cursor.lockState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void LateUpdate () {
		pivot.transform.position = target.transform.position;

		float horizontal = Input.GetAxis("Mouse X")*rotateSpeed;
		pivot.Rotate(0,horizontal,0);

		float vertical = Input.GetAxis("Mouse Y")*rotateSpeed;
		if(invertY)
		{pivot.Rotate(vertical,0,0);}
		else{pivot.Rotate(vertical,0,0);}
		if(pivot.rotation.eulerAngles.x>maxViewAngle && pivot.rotation.eulerAngles.x<180f){
			pivot.rotation = Quaternion.Euler(maxViewAngle,0,0);
		}
		if(pivot.rotation.eulerAngles.x >180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle){
			pivot.rotation = Quaternion.Euler(360f + minViewAngle,0,0);
		}

		float desiredYAngel = pivot.eulerAngles.y;
		float desiredXAngle = pivot.eulerAngles.x;
		Quaternion rotation = Quaternion.Euler(desiredXAngle,desiredYAngel,0);
		transform.position = target.position - (rotation*offset);
		if(transform.position.y< target.position.y){
			transform.position = new Vector3(transform.position.x,target.position.y-.5f, transform.position.z);
		}
		if(transform.position.y > target.position.y){
			transform.position = new Vector3(transform.position.x,transform.position.y-.5f,transform.position.z);
		}
		transform.LookAt(target);
	}
}
