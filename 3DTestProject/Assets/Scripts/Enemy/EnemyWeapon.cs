using System.Collections;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private EnemyBullet enemyBullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float timeBetweenAttacks;

    private bool _canShoot = true;
    
    public void TryShoot(Vector3 targetPoint)
    {
        if (_canShoot)
        {
            var bullet = Instantiate(enemyBullet, shootPoint.position, shootPoint.rotation);
            bullet.Init((targetPoint - bullet.transform.position).normalized);
            _canShoot = false;
            StartCoroutine(WaitForReloadEnd());
        }
    }

    IEnumerator WaitForReloadEnd()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        _canShoot = true;
    }
}
