using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;
    [SerializeField] private float nextDamageTime;

    void Start()
    {
        currentHealth = maxHealth;
    }


    void takeDamage()
    {
        Debug.Log("OUCH THAT HURT");
        currentHealth -= 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Time.time >= nextDamageTime)
        {
            if (collision.collider.gameObject.CompareTag("Enemy"))
            {
                takeDamage();
            }
            nextDamageTime = Time.time + 1f;
        }
    }

    void Update()
    {
        if(currentHealth <=0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("PLAYER DIED");
        
        //PLACE ANIMATION HERE

        this.enabled = false;
        GetComponent<Collider>().enabled = false;
    }
}
