using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecrementBar : MonoBehaviour
{
    public float decrement;
    public float current;
    public float initialValue;

    public ConstructionsSpawn spawn;
    private bool[][] arrayCasas;

    public void Start()
    {
        current = initialValue;
        StartCoroutine(CalculateBarValue());
    }
    // Update is called once per frame
    public void Update()
    {
        arrayCasas = spawn.occupied;
    
    }

    //Esboco inicial do codigo com sono :(, coloquei aqui porque o MainManager ja ta chamando ele, entao achei melhor fazer o calculo localmente mesmo, pode alterar dps sequiser
    IEnumerator CalculateBarValue()
    {
  
            for (int i = 0; i < arrayCasas.Length; i++)
            {
                decrement++;
            }
            current -= Time.deltaTime * (decrement / 10);
            yield return new WaitForSeconds(UnityEngine.Random.Range(0,2));
        

    }
}
