using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {
 
     [SerializeField]private KeyCode attack1;
	 //public KeyCode attack2;
	 [SerializeField] private CharacterController controller;	
	 [SerializeField] private Animator anim;
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(attack1)){
			anim.SetTrigger("Attack");
		}
		
		/*if(Input.GetKey(attack2)){
			anim.SetBool("isAttackin2",true);
		}*/
		
}
}
