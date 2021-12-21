using System;
using UnityEngine;
using UnityEngine.Events;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private float lookSpeed;
    private PlayerInput _playerInput;
    private Vector2 _rotation;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _rotation = new Vector2();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector2 inputDirection = _playerInput.Camera.Look.ReadValue<Vector2>();
        Look(inputDirection);
    }
    
    private void Look(Vector2 direction)
    {
        if(direction.sqrMagnitude < 0.2) return;

        direction *= lookSpeed * Time.deltaTime;

        _rotation.x += -direction.y;
        _rotation.y +=  direction.x;
        _rotation.x = Mathf.Clamp(_rotation.x, -90, 90);
        
        transform.localRotation = Quaternion.Euler(_rotation.x, _rotation.y, 0f);
    }

    
    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
}
