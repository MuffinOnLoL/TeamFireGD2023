using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <=0)
        {
            Die();
        }
    }




    

    void Die()
    {
        Debug.Log("Slime DIED");
        
        //PLACE ANIMATION HERE

        this.enabled = false;
        GetComponent<Collider>().enabled = false;
    }
}
