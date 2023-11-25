using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AddWorkforce : MonoBehaviour

{

    public TMP_Text text;
    private int count = 0;

    public Sprite button;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(count.ToString());
    }

    private void OnMouseDown()
    {
            count += 1;
    }

}
