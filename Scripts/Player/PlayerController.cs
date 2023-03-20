using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float turnSpeed = 360;
    private Animator FrogControl;
    private AudioSource[] sounds;
    private AudioSource footstepSound;
    private Vector3 input;
    private bool jump;

    private float distToGround;
    
    private void Start() 
    {
        FrogControl = GetComponent<Animator> ();
        sounds = GetComponents<AudioSource> ();
        footstepSound = sounds[0];
        distToGround = playerBody.GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        CollectInputer();
        PlayerLook();
        PlayerJump();
        PlayerAnimation();
        PlayerAudio();
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
            FrogControl.SetTrigger("Jump");
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
    }

    void PlayerAnimation()
    {
        var v = Math.Abs(Input.GetAxisRaw ("Horizontal"));
        var h = Math.Abs(Input.GetAxisRaw ("Vertical"));
        FrogControl.SetFloat ("Speed", v + h);
        if (isGrounded()) FrogControl.SetBool("Grounded", true);
        else FrogControl.SetBool("Grounded", false);
    }

    void PlayerAudio()
    {
        if ((Math.Abs(Input.GetAxisRaw ("Horizontal")) + Math.Abs(Input.GetAxisRaw("Vertical"))) > 0 && isGrounded())
        {
            footstepSound.enabled = true;
        }
        else 
        {
            footstepSound.enabled = false;
        }
    }

    
}
