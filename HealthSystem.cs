using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private int numOfHearts;




    // Update is called once per frame
    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        if (health < 1)
        {
            Debug.Log("PLAYER HAS DIED");
            Destroy(gameObject);
        }
        
    }

    public void Damaged()
    {
        health -=1;
        Debug.Log("PLAYER TOOK DAMAGE");
        if (health < numOfHearts)
        {
            numOfHearts = health;
        }
    }
}
