using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    
    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private Rigidbody rigid;

    [Header("Specs")]
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Vector3 moveDir;

    #region Input Actions

    private void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        moveDir.x = inputDir.x;
        moveDir.z = inputDir.y;
    }

    private void OnJump(InputValue value)
    {
        
    }

    #endregion

    private void Awake()
    {
        
    }

    private void Update()
    {
        controller.Move(moveDir * moveSpeed * Time.deltaTime);
    }
}
