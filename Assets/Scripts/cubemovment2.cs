using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cubemovment2 : MonoBehaviour
{
    private TouchControls touchers;
    public bool rotatingCube = true;
    public float rotationSensitivity = 1.5f;

    private Quaternion initialRotation;
    private Quaternion currentRotation;

    private void Awake()
    {
        touchers = new TouchControls();
    }
    void Start()
    {
        touchers.Touch.Drag.started += ctx => StartTouch(ctx);
        initialRotation = transform.rotation;
        currentRotation = Quaternion.identity;
    }

    void Update()
    {
        
        float mouseX = new float();
        float mouseY = new float();
        if (rotatingCube)
        {
            if(touchers.Touch.Drag.inProgress)
            {
                mouseX=touchers.Touch.Drag.ReadValue<Vector2>().x;
                mouseY= touchers.Touch.Drag.ReadValue<Vector2>().y;
            }
            mouseX = Input.GetAxis("Mouse X") * rotationSensitivity;
            mouseY = Input.GetAxis("Mouse Y") * rotationSensitivity;

            Quaternion xAxis = Quaternion.AngleAxis(-mouseX, Vector3.up);
            Quaternion yAxis = Quaternion.AngleAxis(-mouseY, Vector3.right);

            currentRotation = yAxis * xAxis * currentRotation;

            transform.rotation = initialRotation * currentRotation;
        }
    }
    public void StartTouch(InputAction.CallbackContext context)
    {
        rotatingCube = true;
    }

    public void EndTouch(InputAction.CallbackContext context)
    {
        rotatingCube = false;
    }
    private void OnMouseDown()
    {
        rotatingCube = true;
    }

    private void OnMouseUp()
    {
        rotatingCube = false;
    }
    private void OnEnable()
    {
        touchers.Enable();
    }
    private void OnDisable()
    {
        touchers.Disable();
    }


}