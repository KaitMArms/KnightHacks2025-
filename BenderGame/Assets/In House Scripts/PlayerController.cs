using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    private Animator animator;
    public float movementSpeed = 5f, rotationSpeed = 5f, jumpForce = 10f, gravity = -30;
    public int playerHealth = 100;


    private float rotationY;
    private float vertVelocity = -2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void Move(Vector2 input)
    {

        Vector3 move = transform.forward * input.y + transform.right * input.x;
        move = move * movementSpeed * Time.deltaTime;
        characterController.Move(move);

        if(move == Vector3.zero)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
        vertVelocity = vertVelocity + gravity * Time.deltaTime;
        characterController.Move(new Vector3(0, vertVelocity, 0) * Time.deltaTime);
    }

    public void Rotate(Vector2 input)
    {
        rotationY += input.x * rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, rotationY, 0);
    }

    public void Jump()
    {
        if(characterController.isGrounded)
        {
            vertVelocity = jumpForce;
        }
    }
}

