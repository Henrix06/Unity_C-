using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtPlayer(float damage){
        currentHealth -= damage;
        healthText.text = "Health:" +currentHealth;
    }

    public void HealPlayer(float healamount){
        currentHealth += healamount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthText.text = "Health:" +currentHealth;
    }
}
