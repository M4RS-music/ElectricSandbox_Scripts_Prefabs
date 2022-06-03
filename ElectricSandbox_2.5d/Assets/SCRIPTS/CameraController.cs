using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Configurable Properties")]
    [Tooltip("This is the Y offset of our focal point. 0 Means we're looking at the ground.")]
    public float LookOffset;
    [Tooltip("The angle that we want the camera to be at.")]
    public float CameraAngle;
    [Tooltip("The default amount the player is zoomed into the game world.")]
    public float DefaultZoom;
    [Tooltip("The most a player can zoom in to the game world.")]
    public float ZoomMax;
    [Tooltip("The furthest point a player can zoom back from the game world.")]
    public float ZoomMin;
    [Tooltip("How fast the camera rotates")]
    public float RotationSpeed;

    //CameraSpec
    private Camera _actualCamera;
    private Vector3 _cameraPositionTarget;

    //Movement variables
    private const float InternalMoveTargetSpeed = 8;
    private const float InternalMoveSpeed = 4;
    private Vector3 _moveTarget;
    private Vector3 _moveDirection;

    //Zoom variables
    private float _currentZoomAmount;
    public float CurrentZoom
    {
        get => _currentZoomAmount;
        private set
        {
            _currentZoomAmount = value;
            UpdateCameraTarget();
        }
    }
    private float _internalZoomSpeed = 4;

    void Start()
    {
        //Store a reference to the camera rig
        _actualCamera = GetComponentInChildren<Camera>();
        //Set the rotation of the camera based on the CameraAngle property
        _actualCamera.transform.rotation = Quaternion.AngleAxis(CameraAngle, Vector3.right);
        //Set the position of the camera based on the look offset, angle and default zoom properties. 
        //This will make sure we're focusing on the right focal point.
        CurrentZoom = DefaultZoom;
        _actualCamera.transform.position = _cameraPositionTarget;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        //Read the input value that is being sent by the Input System
        Vector2 value = context.ReadValue<Vector2>();
        //Store the value as a Vector3, making sure to move the Y input on the Z axis.
        _moveDirection = new Vector3(value.x, 0, value.y);
    }
    public void OnZoom(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed)
        {
            return;
        }
        // Adjust the current zoom value based on the direction of the scroll - this is clamped to our zoom min/max. 
        CurrentZoom = Mathf.Clamp(_currentZoomAmount - context.ReadValue<Vector2>().y, ZoomMax, ZoomMin);
    }
    private void FixedUpdate()
    {
        //Sets the move target position based on the move direction. Must be done here 
        //as there's no logic for the input system to calculate holding down an input
        _moveTarget += (transform.forward * _moveDirection.z + transform.right *
            _moveDirection.x) * Time.fixedDeltaTime * InternalMoveTargetSpeed;
    }
    private void UpdateCameraTarget()
    {
        _cameraPositionTarget = (Vector3.up * LookOffset) +
            (Quaternion.AngleAxis(CameraAngle, Vector3.right) * Vector3.back) * _currentZoomAmount;
    }
    private void LateUpdate()
    {
        //Lerp  the camera to a new move target position
        transform.position = Vector3.Lerp(transform.position, _moveTarget, Time.deltaTime * InternalMoveSpeed);
        //Move the _actualCamera's local position based on the new zoom factor
        _actualCamera.transform.localPosition = Vector3.Lerp(_actualCamera.transform.localPosition,
            _cameraPositionTarget, Time.deltaTime * _internalZoomSpeed);
    }
}
