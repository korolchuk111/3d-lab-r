using UnityEngine;
using UnityEngine.UI;

public class HealthInfo : MonoBehaviour
{
    [SerializeField] private Text healthText;

    public void OnHealthChanged(float healthCount)
    {
        healthText.text = $"Health: {healthCount}";
    }
}
