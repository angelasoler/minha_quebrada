using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class MainManager : MonoBehaviour
{
    // Start is called before the first frame update

    public float maxValue;
    public float minValue;

    public float currentLifeValue;
    public float initialValue;

    public DecrementBar decrementBar;
    public ConstructionsSpawn spawn;

    private bool[][] arrayCasasOcupadas;

    public void setLifeValue(float value)
    {
        currentLifeValue = value;
        decrementBar.setBarValue(currentLifeValue);
    }

    public void increaseLifeValue(float ammount)
    {
        if (currentLifeValue + ammount <= maxValue)
        {
            currentLifeValue += ammount;
        }
        decrementBar.setBarValue(currentLifeValue);
    }

    public void decreaseLifeValue(float ammount)
    {
        if (currentLifeValue - ammount >= minValue)
        {
            currentLifeValue -= ammount;
        }
        decrementBar.setBarValue(currentLifeValue);
    }

    void Start()
    {
        decrementBar.setMinMax(minValue, maxValue);
        setLifeValue(initialValue);
        StartCoroutine(CalculateBarValue());
    }

    // Update is called once per frame
    void Update()
    {
        arrayCasasOcupadas = spawn.occupied;
    }

    //Esboco inicial do codigo com sono :(, coloquei aqui porque o MainManager ja ta chamando ele, entao achei melhor fazer o calculo localmente mesmo, pode alterar dps sequiser
    // Rlx, adaptei o codigo e agora ele funciona pra aumentar e diminuir o gasto da barra
    IEnumerator CalculateBarValue()
    {

        while (true)
        {
            if (arrayCasasOcupadas != null)
            {
                for (int y = 0; y < arrayCasasOcupadas.Length; y++)
                {
                    for (int x = 0; x < arrayCasasOcupadas.Length; x++)
                    {
                        if (arrayCasasOcupadas[y][x])
                        {
                            if (spawn.constructionGrid[y][x] == ConstructionsSpawn.ConstructionType.Casa)
                            {
                                decreaseLifeValue(0.5f);
                            }
                            if (spawn.constructionGrid[y][x] == ConstructionsSpawn.ConstructionType.Hospital)
                            {
                                increaseLifeValue(1f);
                            }

                        }

                    }

                }
                yield return new WaitForSeconds(UnityEngine.Random.Range(0, 2));
            }
            else
            {
                Debug.Log(arrayCasasOcupadas);
                yield return new WaitForSeconds(UnityEngine.Random.Range(0, 2));
            }
        }


    }
}
