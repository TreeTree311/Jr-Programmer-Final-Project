using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider; // ENCAPSULATION

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
    }
    public void SethHealth(float health)
    {
        slider.value = health;
    }
}
