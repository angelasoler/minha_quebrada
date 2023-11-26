using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour
{
    public ConstructionsSpawn constructionSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        AudioManager.Instance.playSound("compra");
        constructionSpawn.spawnarHospital();
    }
}
