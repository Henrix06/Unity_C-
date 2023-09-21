using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
public string strObj;
public bool destroySelf;
public bool destroyOther;

private void onCollisionEnter(Collision collision){ 

		if(destroySelf){
		Destroy(this.gameObject);}
		if(destroyOther){
		Destroy(collision.gameObject);}}

}
