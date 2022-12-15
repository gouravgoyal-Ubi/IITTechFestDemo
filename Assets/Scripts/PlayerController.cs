using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rot;
    [SerializeField]
    private float rotSpeed;
    [SerializeField] private Animator animator;

    private void Start()
    {
       
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // User input from keyboard 
        float verticalAxis = Input.GetAxis("Vertical"); // up, down, W, S
        float HorizontalAxis = Input.GetAxis("Horizontal"); // right, left, A, D
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Setting animation trigger to attack
            animator.SetTrigger("ToAttack");
        }
        //Setting animation trigger to walk
        animator.SetInteger("WalkSpeed", (int)verticalAxis);

        // To stop animation when player moving backward
        if (verticalAxis < 0)
        {
            verticalAxis = 0;
            animator.SetInteger("WalkSpeed", 0);
        }

        //Rotate player with user input
        rot += HorizontalAxis * rotSpeed * Time.deltaTime;
        //Changing eular angle with provided rotation
        controller.transform.eulerAngles = new Vector3(0, rot, 0);
        // allow character move and collide with objects
        controller.Move(transform.forward * Time.deltaTime * playerSpeed * verticalAxis);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
             playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        // Applying gravity to bring down player
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
