using UnityEngine;

public class ShootModule : MonoBehaviour
{
    [SerializeField] private NewBullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _bulletSpeed = 50;
    
    public void Shoot(Vector3 targetPoint)
    {
        Vector3 bulletStartPosition = _shootPoint.position;
        Vector3 direction = (targetPoint - bulletStartPosition).normalized;
        
        NewBullet bullet = Instantiate(_bullet, bulletStartPosition, _shootPoint.rotation);
        StartBulletFly(bullet.gameObject, direction);
    }

    private void StartBulletFly(GameObject bullet, Vector3 direction)
    {
        bullet.GetComponent<Rigidbody>().AddForce(direction * _bulletSpeed, ForceMode.Impulse);
    }
}