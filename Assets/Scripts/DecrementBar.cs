using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecrementBar : MonoBehaviour
{
    public float decrement;
    public float current;
    public float initialValue;

    public void Start()
    {
        current = initialValue;
    }
    // Update is called once per frame
    public void Update()
    {
        current -= Time.deltaTime * decrement;
    }
}
