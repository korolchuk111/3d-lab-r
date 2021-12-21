using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float gravityModifier;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float jumpHeight;
    [SerializeField] private int jumpCount = 2;
    [SerializeField] private LayerMask layerMask;
    
    private int _jumps;
    private PlayerInput _playerInput;
    private CharacterController _characterController;
    private float _gravity;
    private Vector3 _velocity;
    private float _sphereRadius = 0.4f;
    
    private bool IsGrounded => Physics.CheckSphere(groundChecker.position, _sphereRadius, layerMask);
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();
        _gravity = Physics.gravity.y * gravityModifier;
        _sphereRadius = 0.4f;
        
        _playerInput.Player.Jump.performed += TryJump;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        _velocity.y += _gravity * Time.deltaTime;
        
        if (IsGrounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        } 
        
        if (IsGrounded && _jumps == jumpCount)
        {
            _jumps = 0;
        }
        
        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void TryJump(InputAction.CallbackContext callbackContext)
    {
        if (IsGrounded || (!IsGrounded && _jumps != jumpCount))
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * _gravity);
            _jumps++;
        }
    }
}
