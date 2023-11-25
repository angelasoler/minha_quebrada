using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    // Start is called before the first frame update

    public float maxValue;
    public float minValue;
    public float current;
    public Slider slider;

    public DecrementBar decrementBar;


    void Start()
    {
        slider.minValue = minValue;
        slider.maxValue = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = decrementBar.current;
    }
}
