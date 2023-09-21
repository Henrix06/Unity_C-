using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDamage : MonoBehaviour
{
     [SerializeField]
     private float damage = 1.2f;

     void Start()
     {
         
     }
     void Update()
     {
         
     }

     private void OnTriggerEnter(Collider other)
     {
         FindObjectOfType<HealthManager>().HurtPlayer(damage);
     }
}