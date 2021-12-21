using UnityEngine;

public class NewEnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;

    public void TakeDamage(int damage)
    {
        health += -damage;

        if (health <= 0) 
            Destroy(gameObject.transform.parent.gameObject);
    }
}