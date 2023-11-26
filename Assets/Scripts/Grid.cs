using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public UnityEngine.Object grid;
    public float multiplier;

    [SerializeField] GameObject[] objects;
    public GameObject[] hospitals;

    public Vector3 ConvertCordToVector3(int[] coordinate)
    {
        float convertedX = coordinate[0] * multiplier;
        float convertedY = coordinate[1] * multiplier;

        return new Vector3 (convertedX, convertedY);
    }

    public void spawnHouseInGrid(int[] coordinate)

    {
        //Pega um asset aleatorio de uma pool de assets
        int range = UnityEngine.Random.Range(0, objects.Length - 1);

        Instantiate(objects[range], ConvertCordToVector3(coordinate), Quaternion.identity);
    }

    public void spawnHospitalInGrid(int[] coordinate)
    {
        Debug.Log("spawn");
        int index = UnityEngine.Random.Range(0, hospitals.Length - 1);
        Instantiate(hospitals[index], ConvertCordToVector3(coordinate), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
