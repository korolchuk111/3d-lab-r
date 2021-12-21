using UnityEngine;

public class PickableHealth : MonoBehaviour
{
    [SerializeField] private float healthCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerInteraction playerBase))
        {
            playerBase.AddHealth(healthCount);
            
            Destroy(gameObject);
        }
    }
}
