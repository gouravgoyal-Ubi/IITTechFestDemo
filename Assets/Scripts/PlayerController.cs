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
        //controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        float verticalAxis = Input.GetAxis("Vertical");
        float HorizontalAxis = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("ToAttack");
        }
        if (verticalAxis > 0)
        {
            animator.SetInteger("WalkSpeed", (int)verticalAxis);
        }
        if (verticalAxis < 0)
            verticalAxis = 0;
        rot += HorizontalAxis * rotSpeed * Time.deltaTime;
        controller.transform.eulerAngles = new Vector3(0, rot, 0);
        Vector3 move = transform.forward;
        controller.Move(move * Time.deltaTime * playerSpeed*verticalAxis);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
