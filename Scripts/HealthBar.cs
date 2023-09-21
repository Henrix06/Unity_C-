using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	[SerializeField]
	private Image healthBar;	
	PlayerHealth playerHealth;

	void Start(){
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

	}

	void Update()
	{
		healthBar.fillAmount = playerHealth.health;
	}
}
