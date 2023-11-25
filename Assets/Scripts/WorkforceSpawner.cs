using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkforceSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject prefab;

    public float interval = 2;

    int timesPassed = 0;
    bool didReceive;
    void Start()
    {
        //Funcao sendo chamada a cada 2 segundos
        InvokeRepeating("SpawnWorkforce", interval, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnWorkforce()
    {
        timesPassed++;
        if (
            (Random.Range(1,100) > 75 || timesPassed == 5)
            && didReceive == false)

        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            timesPassed = 0;
            didReceive = true;
        }
    }
}
