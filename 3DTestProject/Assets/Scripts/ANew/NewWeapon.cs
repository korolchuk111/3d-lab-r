using System.Collections;
using UnityEngine;

public class NewWeapon : MonoBehaviour
{
    public string Name;
    public int Ammo;
    [SerializeField] private float _shootingSpeed;
    [SerializeField] private ShootModule _shootModule;

    private bool isCanShoot = true;
    
    public void TryShoot(Vector3 targetPosition)
    {
        if (Ammo > 0 && isCanShoot)
        {
            Ammo--;
            _shootModule.Shoot(targetPosition);
            isCanShoot = false;
            
            StartCoroutine(WaitForPauseEnd());
        }
    }

    public void AddAmmo(int ammoCount)
    {
        Ammo += ammoCount;
    }
    
    private IEnumerator WaitForPauseEnd()
    {
        yield return new WaitForSeconds(_shootingSpeed);
        isCanShoot = true;
    }
}