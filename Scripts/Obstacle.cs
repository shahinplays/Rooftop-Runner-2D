using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damageAmount = 1;

    void Start()
    {
        Destroy(gameObject, 5f);   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if(health != null) 
            {
                health.PlayerGetDamage(damageAmount);
            }
        }
    }
}
