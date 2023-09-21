using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour {
     
	  public int dam;
	  public string strObj;



	public void SendDamage(int dam)
		{
			PlayerHealth playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
			playerStats.TakeDamage(dam);
		}
}
