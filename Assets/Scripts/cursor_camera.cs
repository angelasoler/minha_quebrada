using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cursor_camera : MonoBehaviour
{
    [SerializeField]float mv_parameter = 10;
    public Vector3 cursorPos;
    Resolution resolution;

    void Start()
    {
       //resolution = Screen.resolutions[];
    }

    // Update is called once per frame
    void Update()
    {
        cursorPos = Input.mousePosition;
        cursorPos.z = -10;
        transform.position = cursorPos * mv_parameter;
    }

	private void LateUpdate()
	{
		
	}

	private void FixedUpdate()
	{
		
	}
}
