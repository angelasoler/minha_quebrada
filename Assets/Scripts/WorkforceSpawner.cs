using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkforceSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;

    public float interval = 2;

    int timesPassed = 0;
    bool didReceive;

    public ConstructionsSpawn constructionsSpawn;

    public Grid grid;

    private bool[][] arrayCasas; 

    public int timer;

    public int count;

    public int limit;

    public static WorkforceSpawner Instance;

    public int minXValue;

    public int maxXValue;


    private void Awake()
    {
        Instance = this;
    }

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
            Random.Range(1, 100) > 80 || timesPassed == timer)

            

       for (int y = 0; y < arrayCasas.Length; y++)
            {
                for (int x = 0; x < arrayCasas[y].Length; x++)
                {
                    if (arrayCasas[y][x] && Random.Range(0,2) == 1 && count < limit)
                    {
                        count++;
                        int[] cords = new int[2];
                        cords[0] = x;
                        cords[1] = y+1;
                        Instantiate(prefab, grid.ConvertCordToVector3(cords), Quaternion.identity);
                        AudioManager.Instance.playSound("bolha");
                        timesPassed = 0;
                    }
                }
            }


        }

    public void DecreaseCount()
    {
        count -= 1;
    }
    }

