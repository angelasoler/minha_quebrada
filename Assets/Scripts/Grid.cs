using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public Object house;
    public Object grid;
    public float multiplier;
    public void spawnHouseInGrid(int[] coordinate)
    {
        
        float convertedX = coordinate[0] * multiplier;
        float convertedY = coordinate[1] * multiplier;

        Instantiate(house, new Vector3(convertedX,convertedY), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        int[] cords = new int[2];
        cords[0] = 2;
        cords[1] = 2;
        spawnHouseInGrid(cords);
        cords[0] = 1;
        cords[1] = 2;
        spawnHouseInGrid(cords);

        cords[0] = 0;
        cords[1] = 0;
        spawnHouseInGrid(cords);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
