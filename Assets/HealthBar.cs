using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    Slider healthSlider;

    private void Start()
    {
        healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = playerHealth.maxHealth;
        healthSlider.value = playerHealth.maxHealth;
    }
    private void Update()
    {
        healthSlider.value = playerHealth.health;
    }
}
