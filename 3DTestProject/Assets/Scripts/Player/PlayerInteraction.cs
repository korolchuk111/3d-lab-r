using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private HealthInfo _healthInfo;

    private float _maxHealth;

    private void Start()
    {
        
        _maxHealth = health;
        _healthInfo.OnHealthChanged(health);
    }

    public void AddHealth(float healthCount)
    {
        if (health + healthCount > _maxHealth)
            health = _maxHealth;
        else
        {
            health += healthCount;
        }

        _healthInfo.OnHealthChanged(health);
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        _healthInfo.OnHealthChanged(health);
        
        if(health <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log("You died!");
        Time.timeScale = 0;
    }
}
