using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	public float gravityScale;
	public CharacterController controller;
	private Vector3 moveDirection;
	public Animator anim;
	public Transform pivot;
	public float rotateSpeed;
	public GameObject playerModel;
	//public Joystick joypad;


	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		float yStore = moveDirection.y;
		moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
		//moveDirection = (transform.forward*joypad.Vertical) + (transform.right*joypad.Horizontal);
		moveDirection = moveDirection.normalized*moveSpeed;
		moveDirection.y = yStore;

		if(controller.isGrounded){
			moveDirection.y = 0f;
			if(Input.GetButtonDown("Jump")){
				moveDirection.y = jumpForce;
			}
		}

		moveDirection.y = moveDirection.y + (Physics.gravity.y*gravityScale*Time.deltaTime);
		controller.Move(moveDirection * Time.deltaTime);
//move palyer in different directions
		if(Input.GetAxis("Horizontal")!= 0) 
		{
			transform.rotation = Quaternion.Euler(0f,pivot.rotation.eulerAngles.y,0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x,0f,moveDirection.z));
			playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation,newRotation,rotateSpeed*Time.deltaTime);
		}

		if(Input.GetAxis("Vertical")!=0)
		{
			transform.rotation = Quaternion.Euler(0f,pivot.rotation.eulerAngles.y,0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x,0f,moveDirection.z));
			playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation,newRotation,rotateSpeed*Time.deltaTime);
		}

		anim.SetBool("isGrounded", controller.isGrounded);
		anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + (Mathf.Abs(Input.GetAxis("Horizontal")))));
	}
}
