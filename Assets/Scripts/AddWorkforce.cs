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

    private Vector3 position;

    private void Start()
    {
        text = GameObject.FindGameObjectWithTag("WorkforceText").GetComponent<TMP_Text>();
    }


    // Update is called once per frame
    void Update()
    {
        if (button != null) {
            text.SetText(count.ToString());
            position = transform.position + new Vector3(100f, 100f, 0f);
        }
        
    }

    private void OnMouseDown()
    {
        count += 1;
        audioSource.Play();
        Destroy(button);

        if (button == null)
        {
            Destroy(audioSource);
        }
    }

}
