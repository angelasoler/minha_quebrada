using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cursor_camera : MonoBehaviour
{
    [SerializeField] float mv_parameter = 10;
    public Vector3 cursorPos;
    Resolution resolution;
    Vector3 finalPos;

    void Start()
    {
        //resolution = Screen.resolutions[];
    }

    // Update is called once per frame
    void Update()
    {
        cursorPos = Input.mousePosition;
        finalPos = cursorPos * mv_parameter;
        finalPos.z = -10;
        transform.position = finalPos;
    }

    private void LateUpdate()
    {

    }

    private void FixedUpdate()
    {

    }
}