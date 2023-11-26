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

    private void Start()
    {
        manager = ResourceManager.Instance;
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnMouseDown()
    {
        manager.AddCount();
        audioSource.Play();
        Destroy(gameObject);

        if (button == null)
        {
            Destroy(audioSource);
        }
    }

}
