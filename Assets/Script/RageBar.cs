using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RageBar : MonoBehaviour
{
    
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    
    public void SetMaxRage(int rage)
    {
        slider.maxValue = rage;
        slider.value = rage;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetRage(int rage)
    {
        slider.value = rage;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        
    }
}
