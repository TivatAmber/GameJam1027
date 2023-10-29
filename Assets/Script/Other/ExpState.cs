using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpState : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Player player;
    private void Update()
    {
        slider.minValue = 0;
        slider.maxValue = player.MaxExp;
        slider.value = player.Exp;
    }
}
