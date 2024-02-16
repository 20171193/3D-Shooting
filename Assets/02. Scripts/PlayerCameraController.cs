using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum CameraType
{
    FPS,
    TPS
}

public class PlayerCameraController : MonoBehaviour
{
    [Header("Components")]
    [Space(2)]
    [SerializeField]
    private CinemachineVirtualCamera fpsCamera;
    [SerializeField]
    private Transform fpsCameraRoot;

    [SerializeField]
    private CinemachineVirtualCamera tpsCamera;
    [SerializeField]
    private Transform tpsCameraRoot;

    [Space(3)]
    [Header("Ballancing")]
    [Space(2)]
    [SerializeField]
    private float mouseSensitivity;
    [SerializeField]
    private Vector2 inputDir;
    [SerializeField]
    private CameraType curCameraMode;

    public const float XRotation_Threshold = 80f;

    [SerializeField]
    private float xRotation;
    [SerializeField]
    private float yRotation;

    private void Awake()
    {
        curCameraMode = CameraType.FPS;
    }

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
    private void OnFPSViewMode(InputValue value)
    {
        if (curCameraMode == CameraType.FPS) return;

        ChangeViewMode(CameraType.FPS);
    }
    private void OnTPSViewMode(InputValue value)
    {
        if (curCameraMode == CameraType.TPS) return;

        ChangeViewMode(CameraType.TPS);
    }

    private void ChangeViewMode(CameraType targetView)
    {
        int temp = 0;
        switch(targetView)
        {
            case CameraType.FPS:
                curCameraMode = CameraType.FPS;
                fpsCamera.Priority = temp;
                fpsCamera.Priority = tpsCamera.Priority;
                tpsCamera.Priority = temp;
                break;
            case CameraType.TPS:
                curCameraMode = CameraType.TPS;
                tpsCamera.Priority = temp;
                tpsCamera.Priority = fpsCamera.Priority;
                fpsCamera.Priority = temp;
                break;
            default:
                break;
        }
    }

    // FPS Update
    private void Update()
    {

        if (curCameraMode == CameraType.FPS)
        {
            xRotation -= mouseSensitivity * inputDir.y * Time.deltaTime;
            xRotation = Mathf.Clamp(xRotation, 0f, 140f);
            // Player Rotate
            transform.Rotate(Vector3.up, mouseSensitivity * inputDir.x * Time.deltaTime);
            fpsCameraRoot.localRotation = Quaternion.Euler(xRotation, -90f, 0);
        }
    }

    // TPS LateUpdate
    private void LateUpdate()
    {
        if (curCameraMode == CameraType.TPS)
        {
            yRotation += inputDir.x * mouseSensitivity * Time.deltaTime;
            xRotation -= inputDir.y * mouseSensitivity * Time.deltaTime;
            Mathf.Clamp(yRotation, -XRotation_Threshold, XRotation_Threshold);
            // Player Rotate
            transform.Rotate(Vector3.up, mouseSensitivity * inputDir.x * Time.deltaTime);
            tpsCameraRoot.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        }

    }
}
