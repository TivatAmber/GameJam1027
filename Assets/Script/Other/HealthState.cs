using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthState : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Player player;
    private void Update()
    {
        slider.minValue = 0;
        slider.maxValue = player.MaxHealth;
        slider.value = player.Health;
    }
}
