using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public ShmupPlayerData CurrentPlayerData;
    public Slider slider;

    public void MaxHealth(int Health)
    {
        CurrentPlayerData.HP = Health;
        slider.maxValue = Health;
        slider.value = Health;
    }
    private void Update()
    {
        slider.value = CurrentPlayerData.HP;
    }
}
