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

    public ConstructionsSpawn constructionsSpawn;

    public Grid grid;

    private bool[][] arrayCasas;

    private int element;

    public int timer;



    void Start()
    {
        // constructionsSpawn = GetComponent<ConstructionsSpawn>();
       
        //Funcao sendo chamada a cada 2 segundos
        InvokeRepeating("SpawnWorkforce", interval, interval);
       

    }

    // Update is called once per frame
    void Update()
    {
        //var element = myArray[Random.Range(0, myArray.Length)];
        arrayCasas = constructionsSpawn.occupied;
    }

    void SpawnWorkforce()
    {
        timesPassed++;
        if (
            (Random.Range(1, 100) > 75 || timesPassed == timer))

       for (int y = 0; y < arrayCasas.Length; y++)
            {
                for (int x = 0; x < arrayCasas[y].Length; x++)
                {
                    if (arrayCasas[y][x] && Random.Range(0,2) == 1)
                    {
                        int[] cords = new int[2];
                        cords[0] = x;
                        cords[1] = y+1;
                        Instantiate(prefab, grid.ConvertCordToVector3(cords), Quaternion.identity);
                        timesPassed = 0;
                        didReceive = true;
                    }
                }
            }


        }
    }

