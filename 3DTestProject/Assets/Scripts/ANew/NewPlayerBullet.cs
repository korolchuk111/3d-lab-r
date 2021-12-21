using System.Collections;
using UnityEngine;

public class NewPlayerBullet : NewBullet
{
    [SerializeField] private int damage;
    [SerializeField] private float liveTime;
    [SerializeField] private GameObject particleEffect;
    [SerializeField] private LayerMask _canHitLayers;
    private Vector3 _bulletStartPosition;

    private void Start()
    {
        _bulletStartPosition = transform.position;
        StartCoroutine(DestroyIfLifeTimeEnd());
    }

    private void Update()
    {
        if (Physics.Linecast(_bulletStartPosition, transform.position, out var hit, _canHitLayers))
        {
            if (hit.collider.TryGetComponent(out NewEnemyHealth enemy))
            {
                enemy.TakeDamage(damage);
            }
            
            var particleGameObject = Instantiate(particleEffect, hit.point, Quaternion.LookRotation(-hit.normal));
            Destroy(particleGameObject, 2);
            StopCoroutine(DestroyIfLifeTimeEnd());
            Destroy(gameObject);
        }
    }
    

    IEnumerator DestroyIfLifeTimeEnd()
    {
        yield return new WaitForSeconds(liveTime);
        StopCoroutine(DestroyIfLifeTimeEnd());
        Destroy(gameObject);
    }
}