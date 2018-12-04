using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{

    public float JumpForce = 5;
    public float CounterJumpForceMultiplier = 2.5f;
    public float Gravity = 38;

    float accelerationTimeAirborne = .1f;
    float accelerationTimeGrounded = 0f;
    float moveSpeed = 6;

    Vector3 velocity;
    float velocityXSmoothing;

    private bool JumpButtonPressed = false;

    Controller2D controller;
    Animator animator;

    Vector2 directionalInput;

    void Start()
    {
        controller = GetComponent<Controller2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CalculateVelocity();

        controller.Move(velocity * Time.deltaTime, directionalInput);

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        if (Mathf.Abs(velocity.x) > 0.1)
        {
            animator.SetBool("Is Running", true);
        }
        else
        {
            animator.SetBool("Is Running", false);
        }
        if (velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (velocity.y < 0)
        {
            animator.SetBool("Is Falling", true);
        }
        if (controller.collisions.below)
        {
            animator.SetBool("Is Jumping", false);
            animator.SetBool("Is Falling", false);
        }
    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    public void OnJumpInputDown()
    {
        if (controller.collisions.below)
        {
            JumpButtonPressed = true;
            velocity.y = JumpForce;
            animator.SetBool("Is Jumping", true);
        }
    }

    public void OnJumpInputUp()
    {
        JumpButtonPressed = false;
    }

    void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += -Gravity * Time.deltaTime;
        if (JumpButtonPressed != true && velocity.y > 0)
        {
            velocity.y -= CounterJumpForceMultiplier * Time.deltaTime;
        }

    }
}
