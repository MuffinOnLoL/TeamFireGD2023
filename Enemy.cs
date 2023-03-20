using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private CharacterController controller;
    private GameObject player;

    [Header("Controller Settings")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundDetect = 1.08f;
    [SerializeField] private float speed = 2.0f;
    private float gravity = -9.8f;
    private Vector3 velocity;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("Character Controller is Null in Enemy");
        }
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player is Null in Enemy");
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDetect);
        if (isGrounded == true)
        {
            var direction = player.transform.position - transform.position;
            velocity = speed * direction.normalized;
        }
        velocity.y += gravity * Time.deltaTime;
        transform.LookAt(player.transform);
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.name == "Player")
        {
            collision.GetComponent<HealthSystem>().Damaged();
        }
    }
}
