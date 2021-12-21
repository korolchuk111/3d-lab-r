using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : AggroComponent
{
    [SerializeField] private ShootModule _weapon;
    
    private const string PlayerTag = "Player";
    private Transform _playerTransform;

    public float AttackCooldown = 2;
    private float _attackCooldown;
    private void Start()
    {
        InitializePlayerTransform();
    }

    private void InitializePlayerTransform() =>
        _playerTransform =  GameObject.FindWithTag(PlayerTag).transform;
    
    void Update()
    {
        if (!CooldownDone()) 
            _attackCooldown += -Time.deltaTime;

        if (CooldownDone())
            StartAttack();
    }

    private bool CooldownDone()
    {
        return _attackCooldown <= 0;
    }

    private void StartAttack()
    {
        _attackCooldown = AttackCooldown;
        
        transform.LookAt(_playerTransform);
        _weapon.Shoot(_playerTransform.position);
        
    }
}
