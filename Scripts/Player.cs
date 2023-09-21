using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]private CharacterController controller;
	[SerializeField] private Transform cam;
	[SerializeField] private float speed = 6f;
	//[SerializeField] private float runSpeed = 10f;
	[SerializeField] private float turnSmoothTime = 0.1f;
	float turnSmoothVelocity;
	[SerializeField] private float jumpHeight  = 3f;
	private bool groundedPlayer;
	[SerializeField] private float gravity = -9.81f;
	[SerializeField] private Animator anim;
	 private Vector3 playerVelocity;
	// [SerializeField]  private KeyCode run;

	 [SerializeField] private KeyCode attack;
	

	 private void Start()
	 {
		 controller = gameObject.GetComponent<CharacterController>();
	 }

	void Update(){
		groundedPlayer = controller.isGrounded;
		float horizontal  = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		//float yStore = new Vector3(0f, jump , 0f);
		//float ground  = -0.1f;
		Vector3 direction = new Vector3(horizontal,0f,vertical).normalized;

			if(direction.magnitude >= 0.1f)
			{
				
				float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
				float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity,turnSmoothTime);
				transform.rotation = Quaternion.Euler(0f,angle,0f);
				Vector3 moveDir = Quaternion.Euler(0f,targetAngle,0f)*Vector3.forward;
				controller.Move(moveDir.normalized * speed * Time.deltaTime);	

				
			}


			if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

		if(Input.GetKey(attack)){
			anim.SetBool("isAttacking",true);
		}else{
			anim.SetBool("isAttacking",false);
		}

			
			playerVelocity.y += gravity * Time.deltaTime;
			controller.Move(playerVelocity * Time.deltaTime);
			
		
		anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + (Mathf.Abs(Input.GetAxis("Horizontal")))));
	}
}
