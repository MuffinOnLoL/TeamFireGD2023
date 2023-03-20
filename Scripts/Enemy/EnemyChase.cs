using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    private bool lookat = false;
    public GameObject player;
    private Rigidbody rb;
    [SerializeField] private float speed = 10;
    [SerializeField] private float multiplier = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (PlayerDetect.found)
        {
            lookat = true;
        }
        if (lookat)
        {
            transform.LookAt(player.transform);
            rb.MovePosition(transform.position + (transform.forward).normalized * speed * Time.deltaTime);
            rb.AddForce(speed * multiplier * Time.deltaTime * transform.forward);

            //Vector3 vel = rb.velocity;     
        }
    }
}