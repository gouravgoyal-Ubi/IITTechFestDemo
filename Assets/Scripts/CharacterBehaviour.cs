using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] private CharacterController character;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;

    private Vector3 moveDir = Vector3.zero;
    private float rot;
    private void Start() // will be called once after intilaization
    {
        if (animator == null)
        {
            Debug.LogError("Animator component missing!"); // used for printing Error message on the console window
                                                           // Similarly, we can use Debug.Log() for printing debug messages 
                                                           // and Debug.LogWarning() for printing warning messages
        }
    }

    void Update() // will be called once per frame
    {
        if (Input.GetKeyDown(KeyCode.Q)) // user input: Expecting keyboard input 
        {
            animator.SetTrigger("ToAttack"); // used for setting animator trigger
        }

        float verticalAxis = Input.GetAxis("Vertical"); //user input: Expecting keyboard input(up arrow, down arrow, 'W', 'S')
        float HorizontalAxis = Input.GetAxis("Horizontal");//user input: Expecting keyboard input(left arrow, right arrow, 'A', 'D')

        if (verticalAxis > 0)
        {
            animator.SetInteger("WalkSpeed", (int)verticalAxis);

        }

        Debug.Log("Horizontal axis value::" + HorizontalAxis);

        if (HorizontalAxis > 0)
        {
            moveDir = transform.TransformDirection(moveDir);
            rot += HorizontalAxis * rotSpeed * Time.deltaTime;
            character.transform.eulerAngles = new Vector3(0, rot, 0);
        }

        if (verticalAxis < 0)
        {
            verticalAxis = 0;
        }
        
        moveDir = new Vector3(HorizontalAxis, 0, verticalAxis);
        moveDir *= speed;
        moveDir.y -= 8 * Time.deltaTime;
        character.Move(moveDir * Time.deltaTime);
    }
}
