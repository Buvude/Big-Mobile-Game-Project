using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemovment2 : MonoBehaviour
{
    public bool rotatingCube = true;
    public float rotationSensitivity = 1.5f;

    private Quaternion initialRotation;
    private Quaternion currentRotation;

    void Start()
    {
        initialRotation = transform.rotation;
        currentRotation = Quaternion.identity;
    }

    void Update()
    {
        if (rotatingCube)
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSensitivity;

            Quaternion xAxis = Quaternion.AngleAxis(-mouseX, Vector3.up);
            Quaternion yAxis = Quaternion.AngleAxis(mouseY, Vector3.right);

            currentRotation = yAxis * xAxis * currentRotation;

            transform.rotation = initialRotation * currentRotation;
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