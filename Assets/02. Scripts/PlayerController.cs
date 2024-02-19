using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Components
    [Header("Components")]
    [Space(2)]
    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private Animator anim;

    [Space(3)]
    #endregion

    #region Specs 
    [Header("Specs")]
    [Space(2)]
    [SerializeField]
    private float runSpeed;

    [SerializeField]
    private float walkSpeed;
    
    [SerializeField]
    private float jumpSpeed;
    [Space(3)]
    #endregion

    #region Layers
    [Header("Layers")]
    [Space(2)]
    LayerMask groundLayerMask;


    [Space(3)]
    #endregion

    [Header("Ballancing")]
    [Space(2)]
    [SerializeField]
    private Vector3 moveDir;
    [SerializeField]
    private float ySpeed;
    [SerializeField]
    private bool isGround;
    [SerializeField]
    private bool isWalk;
    [SerializeField]
    public int groundCount;

    #region Input Actions
    private void OnWalk(InputValue value)
    {
        if(value.isPressed)
        {
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }
    }
    private void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        moveDir.x = inputDir.x;
        moveDir.z = inputDir.y;
    }
    private void Move()
    {
        float moveSpeed = isWalk ? walkSpeed : runSpeed;  

        controller.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);
        controller.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);

        anim.SetFloat("XSpeed", moveDir.x * moveSpeed, 0.1f, Time.deltaTime);
        anim.SetFloat("YSpeed", moveDir.z * moveSpeed, 0.1f, Time.deltaTime);
    }

    private void OnJump(InputValue value)
    {
        //ySpeed = controller.isGrounded ? jumpSpeed : 0;
        ySpeed = jumpSpeed;
        JumpMove();
    }
    private void JumpMove()
    {
        //if (controller.isGrounded) return;
        ySpeed += Physics.gravity.y * Time.deltaTime;
        controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }

    private void OnFire(InputValue value)
    {
        Fire();
    }
    private void Fire()
    {
        anim.SetTrigger("Fire");
    }

    #endregion

    #region Collision Callback

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    #endregion


    private void Awake()
    {
        
    }

    private void Update()
    {
        Move();
        JumpMove();
    }
}
