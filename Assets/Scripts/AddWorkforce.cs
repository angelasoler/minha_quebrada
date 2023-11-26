using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AddWorkforce : MonoBehaviour

{

    public TMP_Text text;

    public SpriteRenderer button;

    public AudioSource audioSource;

    private ResourceManager manager;

    AudioManager audioManager;

    private void Start()
    {
        manager = ResourceManager.Instance;
        audioManager = AudioManager.Instance;
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnMouseDown()
    {
        manager.AddCount();
        audioManager.playSound("const_hospital");
        Destroy(gameObject);

    }

}
