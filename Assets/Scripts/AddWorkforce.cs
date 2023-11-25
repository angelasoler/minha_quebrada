using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AddWorkforce : MonoBehaviour

{

    public TMP_Text text;
    private int count = 0;

    public SpriteRenderer button;

    public AudioSource audioSource;
    

    // Update is called once per frame
    void Update()
    {
        if (button != null) {
            text.SetText(count.ToString());
        }
        
    }

    private void OnMouseDown()
    {
        count += 1;
        audioSource.Play();
        Destroy(button);
        if (button == null )
        {
            Destroy(audioSource);
        }
    }

}
