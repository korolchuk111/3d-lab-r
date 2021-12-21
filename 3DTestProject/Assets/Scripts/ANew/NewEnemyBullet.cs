using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyBullet : NewBullet
{
    [SerializeField] private float damage;
    [SerializeField] private float liveTime;
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
            if (hit.collider.TryGetComponent(out PlayerInteraction player))
            {
                player.ApplyDamage(damage);
            }
            
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