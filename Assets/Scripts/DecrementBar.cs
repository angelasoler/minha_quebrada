using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecrementBar : MonoBehaviour
{

    public Slider slider;

    public void setMinMax(float minValue, float maxValue)
    {
        slider.minValue = minValue;
        slider.maxValue = maxValue;
    }
    public void setBarValue(float value)
    {
        slider.value = value;
    }

    
}
