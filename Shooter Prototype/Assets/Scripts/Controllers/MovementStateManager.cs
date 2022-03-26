using UnityEngine;
//using Photon.Pun;

public class MovementStateManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] float jumpHeight;
    Vector3 moveDir;
    float hzInput, verInput;
    [SerializeField] CharacterController characterController;
    //public PhotonView view;

    //checking grounded
    [SerializeField] LayerMask groundMask;
    [SerializeField] float GroundYOffset;
    Vector3 footPos;

    [SerializeField] float gravity;
    Vector3 velocity;

    //animation transitions
    Animator animator;

    MovementBaseState currentState;
    public IdleState idle = new IdleState();
    public CrouchState crouch = new CrouchState();
    public RunState run = new RunState();

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        SwitchState(idle);

    }

    // Update is called once per frame
    void Update()
    {
        //if (view.IsMine)
            GetInputsAndMove();
        GravityEffect();
        currentState.UpdateState(this);
    }

    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    void GetInputsAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");
        
        moveDir = transform.forward * verInput + transform.right * hzInput;
        characterController.Move(moveDir.normalized * moveSpeed * Time.deltaTime);

        animator.SetFloat("hInput", hzInput);
        animator.SetFloat("vInput", verInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    bool IsGrounded()
    {
        footPos = new Vector3(transform.position.x, transform.position.y - GroundYOffset, transform.position.z);
        if (Physics.CheckSphere(footPos, characterController.radius - 0.05f, groundMask)) return true;
        return false;

    }

    void GravityEffect()
    {
        if (!IsGrounded()) velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        if (IsGrounded())
        {
            velocity.y = jumpHeight;
            animator.SetTrigger("Jump");
        }
            
            
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(footPos, characterController.radius - 0.05f);
    }

    public Vector3 GetMoveDir()
    {
        return moveDir;
    }

    public Animator GetAnimator()
    {
        return animator;
    }
}
