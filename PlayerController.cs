using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float turnSpeed = 360;
    private Vector3 input;
    private bool jump;

    [SerializeField] private int Damage = 10;
    [SerializeField] private float Distance;
    [SerializeField] private float MaxDistance = 2;


    private float distToGround;
    
    private void Start() 
    {
        distToGround = playerBody.GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        CollectInputer();
        PlayerLook();
        PlayerJump();
        if(Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("PLAYER ATTACKED");
        RaycastHit hit;
        if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                Debug.Log("I HIT AN ENEMY");
            }
        }

    }

    void FixedUpdate()
    {
        
        PlayerMove();  
        
    }

    void CollectInputer()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        jump = (Input.GetButtonDown("Jump"));
        
    }

    void PlayerLook()
    {
        if (input != Vector3.zero)
        {
            var relative = (transform.position + input.isoDir()) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime).normalized;
        }
    }
    void PlayerMove()
    {
        playerBody.MovePosition(transform.position + (transform.forward * input.magnitude).normalized * speed * Time.deltaTime);
    }
    void PlayerJump()
    {
        if (jump && isGrounded())
        {
            playerBody.AddForce((Vector3.up * jumpForce), ForceMode.VelocityChange);
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
    }
}
