using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCameraController : MonoBehaviour
{
    [Header("Components")]
    [Space(2)]
    [SerializeField]
    private CinemachineVirtualCamera fpsCamera;

    [SerializeField]
    private Transform cameraRoot;

    [Space(3)]

    [Header("Ballancing")]
    [Space(2)]
    [SerializeField]
    private float mouseSensitivity;
    [SerializeField]
    private Vector2 inputDir;

    public const float YRotation_Threshold = 80f;
    [SerializeField]
    private float yRotation;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnLook(InputValue value)
    {
        inputDir = value.Get<Vector2>();
    }
    private void Update()
    {
        yRotation -= mouseSensitivity * inputDir.y * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, 0f, 150f);

        transform.Rotate(Vector3.up, mouseSensitivity * inputDir.x * Time.deltaTime);
        cameraRoot.localRotation = Quaternion.Euler(yRotation, -90f, 0);
    }
}
