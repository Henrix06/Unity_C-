using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]private float playerSpeed = 2.0f;
    [SerializeField]private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform target;
    
	[SerializeField] private float turnSmoothTime = 0.1f;
	float turnSmoothVelocity;
    [SerializeField] private Transform cam;
    [SerializeField]private KeyCode attack1;
    [SerializeField]private KeyCode attack2;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        
        if(move.magnitude >=0.1f){
            float targetAngle = Mathf.Atan2(move.x,move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
				float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity,turnSmoothTime);
				transform.rotation = Quaternion.Euler(0f,angle,0f);
				Vector3 moveDir = Quaternion.Euler(0f,targetAngle,0f)*Vector3.forward;
				controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
        }


        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            //anim.SetBool("isGrounded",false);
            anim.SetTrigger("Jump");
        }
            
        if(Input.GetKeyDown(attack1)){
			anim.SetTrigger("Attack");
            playerSpeed = 0;
		}else{
            playerSpeed = 8;
        }

        if(Input.GetKeyDown(attack2)){
			anim.SetTrigger("Attack2");
            playerSpeed = 0;
		}else{
            playerSpeed = 8;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        anim.SetBool("isGrounded",true);
        controller.Move(playerVelocity * Time.deltaTime);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal"))+ Input.GetAxis("Vertical")));

        
    }
}
