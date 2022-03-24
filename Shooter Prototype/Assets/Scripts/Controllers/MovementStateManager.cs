using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    Vector3 moveDir;
    float hzInput, verInput;
    [SerializeField] CharacterController characterController;

    //checking grounded
    [SerializeField] LayerMask groundMask;
    [SerializeField] float GroundYOffset;
    Vector3 footPos;

    [SerializeField] float gravity;
    Vector3 velocity;

    //animation transitions
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputsAndMove();
        GravityEffect();
    }

    void GetInputsAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");
        
        moveDir = transform.forward * verInput + transform.right * hzInput;
        characterController.Move(moveDir * moveSpeed * Time.deltaTime);

        animator.SetFloat("hInput", hzInput);
        animator.SetFloat("vInput", verInput);
        if (hzInput == 0 && verInput == 0) animator.SetBool("Running", false);
        else animator.SetBool("Running", true);
    }

    bool IsGrounded()
    {
        footPos = new Vector3(transform.position.x, transform.position.y - GroundYOffset, transform.position.z);
        if (Physics.CheckSphere(footPos, characterController.radius - 0.05f, groundMask)) return true;
        return false;

    }

    void GravityEffect()
    {
        if (IsGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) velocity.y = -2;

        characterController.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(footPos, characterController.radius - 0.05f);
    }
}
