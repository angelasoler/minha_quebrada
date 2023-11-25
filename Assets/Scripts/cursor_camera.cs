using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cursor_camera : MonoBehaviour
{
    [SerializeField] float mv_parameter = 10;
    public Vector3 cursorPos;
    //Resolution resolution;
    Vector3 finalPos;
    public Vector3 minPos, maxPos;

    void Start()
    {
    }   

    void Update()
    {
        cursorPos = Input.mousePosition;
        finalPos.x = 11.14f + (cursorPos.x * mv_parameter);
        finalPos.y = 4.85f;
        finalPos.z = -10;
        if (finalPos.x > minPos.x && finalPos.x < maxPos.x)
        {
            transform.position = finalPos;
        }
    }
}
