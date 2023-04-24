using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMovment : MonoBehaviour
{
    public bool rotatingCube=true;
    public Vector2 turn;
    public float rotationSensativity=1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotatingCube)
        {
            turn.x += Input.GetAxis("Mouse X")*rotationSensativity;
            turn.y += Input.GetAxis("Mouse Y")*rotationSensativity;
            transform.rotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
        
    }

    private void OnMouseDown()
    {
        rotatingCube = true;
    }
    private void OnMouseUp()
    {
        rotatingCube = false;
    }
}
