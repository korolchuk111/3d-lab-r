using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyWeapon weapon;
    [SerializeField] private Transform target;
    
    private void Update()
    {
        weapon.TryShoot(target.position);
    }
}
