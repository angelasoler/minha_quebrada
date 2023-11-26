using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public TMP_Text text;

    public static ResourceManager Instance;

    public int count = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(count.ToString());
    }

    public void AddCount()
    {
        count++;
    }

    public void RemoveCount(int amount)
    {
        count -= amount;
    }
}
