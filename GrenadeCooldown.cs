using UnityEngine;
using UnityEngine.UI;

public class GrenadeCooldown : MonoBehaviour
{
    public Slider slider;

    public void SetMaxCooldown(int cooldown)
    {

        slider.maxValue = cooldown;
        slider.value = cooldown;

    }

    public void Setcooldown(int cooldown)
    {

        slider.value = cooldown;

    }

}

