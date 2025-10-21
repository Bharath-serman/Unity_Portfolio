using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;
    public float gravity = -9.81f; // gravity force
    public float groundCheckOffset = -0.2f; // helps stay grounded

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the character is grounded
        isGrounded = controller.isGrounded;

        // If grounded and moving downward, reset vertical velocity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = groundCheckOffset;
        }

        // Movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Rotate player
        transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime);

        // Move forward/backward
        Vector3 move = transform.forward * vertical;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
