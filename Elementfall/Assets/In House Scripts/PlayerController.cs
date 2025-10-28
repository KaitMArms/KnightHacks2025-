using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    private Animator animator;
    public float movementSpeed = 5f, rotationSpeed = 5f, jumpForce = 10f, gravity = -30;
    public int playerHealth = 100;


    private float rotationY;
    private float vertVelocity = -2f;

    private int direction = 0;
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

        // if (move == Vector3.zero)
        // {
        //     animator.SetBool("isRunning", false);
        // }
        // else
        // {
        //     animator.SetBool("isRunning", true);
        // }
        
        






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
        if (characterController.isGrounded)
        {
            vertVelocity = jumpForce;
        }
    }

    public void Update()
    {

        // Read raw input and set animator booleans accordingly.
        // Direction integer is ignored per request; we rely purely on animator flags.
        bool up = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool left = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        // Diagonals take precedence when two directions are pressed.
        animator.SetBool("bl", down && left);
        animator.SetBool("br", down && right);

        // Cardinal directions only when not part of a diagonal.
        animator.SetBool("f", up);
        animator.SetBool("b", down && !left && !right);
        animator.SetBool("l", left && !up && !down);
        animator.SetBool("r", right && !up && !down);

        animator.SetBool("isJumping", Input.GetKey(KeyCode.Space));

        Debug.Log(animator.GetBool("bl"));
        Debug.Log(animator.GetBool("br"));
        Debug.Log(animator.GetBool("f"));
        Debug.Log(animator.GetBool("b"));
        Debug.Log(animator.GetBool("l"));
        Debug.Log(animator.GetBool("r"));
        Debug.Log("end");

    }
}

