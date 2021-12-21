using System;
using UnityEngine;

public class PickableBullet : MonoBehaviour
{
    [SerializeField] private int bulletCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerWeapons playerAttack))
        {
            playerAttack.AddAmmoToCurrentWeapon(bulletCount);
            Destroy(gameObject);
        }
    }
}
